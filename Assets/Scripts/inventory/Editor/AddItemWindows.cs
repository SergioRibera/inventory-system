using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class AddItemWindows : EditorWindow {

    private static ScriptableInventory database;
    private static EditorWindow window;

    private static Item newItem;
    private GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(20.0f) };

    static GUIStyle h1 = new GUIStyle();
    static GUIStyle textAreaStyle = new GUIStyle();
    static GUIStyle valueStyle = new GUIStyle();
    Vector2 scroll, scrollDialog;
    public static void ShowWindow(ScriptableInventory db)
    {
        database = db;
        window = GetWindow<AddItemWindows>();
        window.minSize = new Vector2(300, 380);
        newItem = new Item(db.ItemsCount + 1, "", "", "");
        newItem.editorShow = true;
        newItem.selected = false;
        textAreaStyle.wordWrap = true;
        valueStyle.wordWrap = true;
        valueStyle.alignment = TextAnchor.MiddleLeft;
        h1.fontSize = 16;
        window.titleContent = new GUIContent("Add new Item");
    }

    public void OnGUI()
    {
        DisplayItem(newItem);
        if (GUILayout.Button("Confirm"))
            AddItem();
    }
    private void DisplayItem(Item item)
    {
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Name: ");
            item.name = EditorGUILayout.TextField(item.name, options);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Descripción:");
            scroll = EditorGUILayout.BeginScrollView(scroll);
            item.description = EditorGUILayout.TextArea(item.description, GUILayout.Height(position.height - 10));
            EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Seller Dialog: ");
            scrollDialog = EditorGUILayout.BeginScrollView(scrollDialog);
            item.sellerDialog = EditorGUILayout.TextArea(item.sellerDialog, GUILayout.Height(position.height - 10));
            EditorGUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();
        GUILayout.Label("Collectable Data:");
        EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Min Amount:");
                item.collectableData.minAmount = EditorGUILayout.IntField(item.collectableData.minAmount, options);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Max Amount:");
                item.collectableData.maxAmount = EditorGUILayout.IntField(item.collectableData.maxAmount, options);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Max Stacks:");
                item.collectableData.maxStacks = EditorGUILayout.IntField(item.collectableData.maxStacks, options);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Min Level To Unlock:");
                item.collectableData.minLevelUnlock = EditorGUILayout.IntField(item.collectableData.minLevelUnlock, options);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Stackable:");
                item.collectableData.stackable = EditorGUILayout.Toggle(item.collectableData.stackable, options);
            EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        GUILayout.Label("Collectable Data:");
        EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Cost in Runas:");
                item.cost.costRuna = EditorGUILayout.IntField(item.cost.costRuna, options);
            EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndVertical();
    }

    private void AddItem()
    {
        Undo.RecordObject(database, "Item Added");
        database.inventory.Add(newItem);
        EditorUtility.SetDirty(database);
        window.Close();
    }
}