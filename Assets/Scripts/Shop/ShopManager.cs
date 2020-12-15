﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ShopManager : MonoBehaviour
{
    [ReadOnly] public PlayerData data;
    public ScriptableInventory dataBase;
    public GameObject prefabItem;
    public Transform[] positions;
    public List<Item> itemsOffer;

    void Awake() {
        PlayerDataManager.Load();
        data = PlayerDataManager.data;
    }
    void Start() {
        List<int> indexs = GenerateRandom(4, 1, dataBase.ItemsCount);
        foreach(var i in indexs)
            itemsOffer.Add(dataBase.inventory.Get(i));
        InstanceItems();
    }

    void InstanceItems(){
        int i = 0;
        foreach(var item in itemsOffer){
            GameObject go = Instantiate(prefabItem, positions[i]);
            go.transform.SetParent(positions[i]);
            ItemObject io = go.GetComponent<ItemObject>();
            io.SetTextToHover(i, this, $"{item.name} a {item.cost.costRuna} Runas.");
            io.onClick += (index) => {
                itemsOffer[index].selected = !itemsOffer[index].selected;
            };
            i++;
        }
    }

    public List<int> GenerateRandom(int count, int min, int max) {
        if (max <= min || count < 0 || (count > max - min && max - min > 0))
            throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                    " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
        Random random = new Random();
        HashSet<int> candidates = new HashSet<int>();
        for (int top = max - count; top < max; top++)
            if (!candidates.Add(random.Next(min, top + 1)))
                candidates.Add(top);

        List<int> result = candidates.ToList();

        for (int i = result.Count - 1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            int tmp = result[k];
            result[k] = result[i];
            result[i] = tmp;
        }
        return result;
    }
}
