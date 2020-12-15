using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScriptableInventory))]
public class LanguajeBaseEditor : Editor {
    private ScriptableInventory database;
    private string searchString = "";
    private bool shouldSearch;

    Item newItem;

    GUIStyle layoutWrap = new GUIStyle();
    GUIStyle h1 = new GUIStyle();

    private void OnEnable()
    {
        database = (ScriptableInventory)target;
        layoutWrap.wordWrap = true;
        h1.fontSize = 16;
    }
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (database)
        {
            EditorGUILayout.BeginVertical("Box");
            GUILayout.Label("Items in DataBase: " + database.ItemsCount);
            if(database.ItemsCount > 0)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label("Search: ");
                searchString = GUILayout.TextField(searchString);
                EditorGUILayout.EndHorizontal();
            }
            if (GUILayout.Button("Add new Item"))
                AddLanguajeWindows.ShowWindow(database);
            /*if (GUILayout.Button("Add new Content"))
                AddContentWindows.ShowWindow(database);*/
            EditorGUILayout.EndVertical();
            shouldSearch = !string.IsNullOrEmpty(searchString);
            foreach (var item in database.inventory.items)
            {
                if (shouldSearch)
                {
                    if (item.name == searchString || item.name.Contains(searchString))
                        DisplayItem(item);
                }
                else
                    DisplayItem(item);
            }
            //if(deleteItem != null)
            //    database.items.Remove(deleteItem);
        }
    }

    //Item deleteItem;

    private void DisplayItem(Item item)
    {
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label(item.name, h1);
            if (GUILayout.Button(item.editorShow ? "Hidden" : "Show", GUILayout.MaxWidth(80)))
                item.editorShow = !item.editorShow;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Nombre:");
            GUILayout.Label(item.name);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Descripción:");
            GUILayout.Label(item.description);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Nombre:");
            GUILayout.Label(item.name);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Nombre:");
            GUILayout.Label(item.name);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical(GUILayout.MaxWidth(5));
        if (GUILayout.Button("Edit"))
            ContentModifiWindows.ShowWindow(database, item.id);
        if (GUILayout.Button("Delete"))
            if (EditorUtility.DisplayDialog("Are you sure?", "Are you sure you want to delete this item?", "Acept"))
                database.inventory.Remove(item);
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.EndVertical(); // Box
    }
}