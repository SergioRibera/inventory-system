using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyDataSave;

public class PlayerDataManager
{
    public static PlayerData data {
        private set;
        get;
    }
    public static void Load() =>
        data =
            SaveDataManager.Exist(typeof(PlayerData), PersistentData.SAVE_PATH) ?
            SaveDataManager.Load<PlayerData>(PersistentData.SAVE_PATH, PersistentData.KEY_ENCRYPT_DATA, true) :
            new PlayerData();

    static void Save() => SaveDataManager.Save(data, PersistentData.SAVE_PATH, PersistentData.KEY_ENCRYPT_DATA, true);

#region Getters
    public static string Name => data.name;
    public static int Runas => data.runas;
    public static InventoryModel Inventory => data.inventory;

    public static Item GetItem(int id) => data.inventory.Get(id);
#endregion

#region Setters
    public static void SetName(string n){
        data.name = n;
        Save();
    }
    public static void SetRunas(int r){
        data.runas = r;
        Save();
    }
#endregion
#region Modify
    public static void AddNewItem(Item i){
        if(!data.inventory.Exists(i.id))
            data.inventory.Add(i);
        else
            data.inventory.Modify(i);
    }
    ///
    /// <summary>Esta funcion sirve para Agregar más items y crear slots nuevos
    /// de items</summary>
    ///
    public static void AddMoreItem(Item i){
        if(!data.inventory.Exists(i.id))
            throw new Exception($"Item with ID '${i.id}' to modify not exist on inventory");
        /*Item currentItem = data.inventory.Get(i);
        int itemsTotals = currentItem.amount + i.amount;
        if(itemsTotals <= currentItem.maxAmount){
            
        } else {
            i.amount -= currentItem.maxAmount;
            AddMoreItem(i);
        }*/
    }
    public static void ModifyItem(Item i){
        if(!data.inventory.Exists(i.id))
            throw new Exception($"Item with ID '${i.id}' to modify not exist on inventory");
        else
            data.inventory.Modify(i);
    }
#endregion
}
