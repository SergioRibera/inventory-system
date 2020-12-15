using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryModel
{
    public List<Item> items;

    public InventoryModel(){
        items = new List<Item>();
    }

    public bool Exists(int id) => Get(id) != null;
    public Item Get(int id){
        Item old = items.Find(x => x.id == id);
        Item i = new Item(old.id, old.name, old.description, old.sellerDialog);
        i.selected = false;
        i.collectableData.amount = old.collectableData.amount;
        i.collectableData.maxAmount = old.collectableData.maxAmount;
        i.collectableData.minAmount = old.collectableData.minAmount;
        i.collectableData.maxStacks = old.collectableData.maxStacks;
        i.collectableData.minLevelUnlock = old.collectableData.minLevelUnlock;
        i.collectableData.stackable = old.collectableData.stackable;
        i.cost.costRuna = old.cost.costRuna;
        return i;
    }
    public Item Get(Item i) => Get(i.id);
    public void Add(Item item) => items.Add(item);
    public void Modify(int index, Item item) => items[index] = item;
    public void Modify(Item item){
        int index = items.IndexOf(item);
        Modify(index, item);
    }
    public void Remove(Item item) => items.Remove(item);
}
