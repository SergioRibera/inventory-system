using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryModel
{
    List<Item> items;

    public InventoryModel(){
        items = new List<Item>();
    }

    public bool Exists(int id) => Get(id) != null;
    public Item Get(int id) => items.Find(i => i.id == id);
    public Item Get(Item i) => Get(i.id);
    public void Add(Item item) => items.Add(item);
    public void Modify(int index, Item item) => items[index] = item;
    public void Modify(Item item){
        int index = items.IndexOf(item);
        Modify(index, item);
    }
    public void Remove(Item item) => items.Remove(item);
}
