using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ContentModifiWindows : EditorWindow {

    static ScriptableInventory database;
    static EditorWindow window;

    static int idElement;
    Vector2 scroll, scrollDialog;
    static GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(20.0f) };
    public static void ShowWindow(ScriptableInventory db, int _id)
    {
        database = db;
        idElement = _id;
        window = GetWindow<ContentModifiWindows>();
        window.titleContent = new GUIContent("Edit Content For Languajes");
        window.minSize = new Vector2(300, 380);
        /*contents = new List<string>();
        foreach (var idioma in db.idiomas)
            contents.Add(idioma.GetContent(idElement).content);*/
    }

    public void OnGUI()
    {
        DisplayItem(database.inventory.Get(idElement));
        if (GUILayout.Button("Confirm Edit"))
            AddContents();
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

    private void AddContents()
    {
        Undo.RecordObject(database, "Content Added");
        EditorUtility.SetDirty(database);
        window.Close();
    }
}