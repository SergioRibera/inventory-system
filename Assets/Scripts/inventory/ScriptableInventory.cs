using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class ScriptableInventory : ScriptableObject {
    [HideInInspector] public InventoryModel inventory = new InventoryModel();
    public int ItemsCount {
        get{
            return inventory.items.Count;
        }
    }
}
