using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class ScriptableInventory : ScriptableObject {
    public InventoryModel inventory;
    public int ItemsCount {
        get{
            return inventory.items.Count;
        }
    }
}
