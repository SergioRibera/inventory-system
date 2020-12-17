using System;

[Serializable]
public class PlayerData
{
    public string name;
    public int runas;
    public InventoryModel inventory;

    public PlayerData(){
        inventory = new InventoryModel();
    }
}
