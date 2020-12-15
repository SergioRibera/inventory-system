using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int id;
    public string name, description;
    public List<string> sellerDialogs;
    public bool selected;
    public ItemCollectable collectableData;
    public CostItem cost;

    public Item(int i, string n, string desc){
        id = i;
        name = n;
        description = desc;
        sellerDialogs = new List<string>();
        collectableData = new ItemCollectable();
        cost = new CostItem();
    }
}
[Serializable]
public class ItemCollectable {
    public int amount, maxAmount, minAmount, maxStacks, minLevelUnlock;
    public bool stackable;
    
    public ItemCollectable(){
        amount = 0;
        maxAmount = 64;
        minAmount = 0;
        maxStacks = 10;
        minLevelUnlock = 0;
        stackable = true;
    }
}
public struct CostItem {
    public int costRuna;

    public CostItem(){
        costRuna = 0;
    }
}
