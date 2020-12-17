using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [ReadOnly] public PlayerData data;
    public ScriptableInventory dataBase;
    public GameObject prefabItem;
    public Transform[] positions;
    public List<Item> itemsOffer;
    [Header("UI")]
    public TextMeshProUGUI runaText;
    public GameObject dialogContainer;
    public TextMeshProUGUI dialogText;

    List<ItemObject> itemObjects = new List<ItemObject>();
    int costTotal = 0;
    void Awake() {
        PlayerDataManager.Load();
        if(string.IsNullOrEmpty(PlayerDataManager.Name)){
            PlayerDataManager.SetName("Sergio Ribera");
            PlayerDataManager.SetRunas(10549);
        }
        data = PlayerDataManager.data;
    }
    void Start() {
        List<int> indexs = GenerateRandom(4, 1, dataBase.ItemsCount);
        foreach(var i in indexs)
            itemsOffer.Add(dataBase.inventory.Get(i));
        InstanceItems();
        runaText.text = PlayerDataManager.Runas + " Runas";
    }

    void InstanceItems(){
        int i = 0;
        foreach(var item in itemsOffer){
            GameObject go = Instantiate(prefabItem, positions[i]);
            go.transform.SetParent(positions[i]);
            ItemObject io = go.GetComponent<ItemObject>();
            io.SetTextToHover(i, item.id, this, $"{item.name} a {item.cost.costRuna} Runas.", item.description);
            io.onClick += (index) => {
                itemsOffer[index].selected = !itemsOffer[index].selected;
            };
            itemObjects.Add(io);
            i++;
        }
    }

    public void Buy(){
        List<Item> selecteds = itemsOffer.Where(i => i.selected).ToList();
        foreach(var s in selecteds)
            costTotal += s.cost.costRuna;
        if(costTotal > PlayerDataManager.Runas){
            ShowDialog("Not have Runas for buy");
            return;
        }
        foreach(var s in selecteds) {
            ItemObject sio = itemObjects.Find(io => io.id == s.id);
            Image imageSio = sio.gameObject.GetComponent<Image>();
            imageSio.color = sio.hover;
            imageSio.raycastTarget = false;
            sio.Interactable = false;
            s.selected = false;
            PlayerDataManager.AddNewItem(s);
        }
        PlayerDataManager.SetRunas(PlayerDataManager.Runas - costTotal);
        runaText.text = PlayerDataManager.Runas + " Runas";
    }

    public void ShowDialog(string text){
        dialogContainer.SetActive(true);
        dialogText.text = text;
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
