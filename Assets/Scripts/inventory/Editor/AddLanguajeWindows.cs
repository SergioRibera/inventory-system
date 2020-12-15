using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class AddLanguajeWindows : EditorWindow {

    private static ScriptableInventory database;
    private static EditorWindow window;

    private static Item newItem;
    private GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(20.0f) };

    static GUIStyle h1 = new GUIStyle();
    static GUIStyle textAreaStyle = new GUIStyle();
    static GUIStyle valueStyle = new GUIStyle();
    public static void ShowWindow(ScriptableInventory db)
    {
        database = db;
        window = GetWindow<AddLanguajeWindows>();
        window.minSize = new Vector2(300, 380);
        newItem = new Item(db.ItemsCount + 1, "", "");
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
        EditorGUILayout.EndVertical();
    }

    private void AddItem()
    {
        Undo.RecordObject(database, "Item Added");
        database.inventory.Add(newItem);
        //var agregedIdioma = database.GetIdioma(newItem.Name);
        EditorUtility.SetDirty(database);
        window.Close();
    }
}