using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ContentModifiWindows : EditorWindow {

    static ScriptableInventory database;
    static EditorWindow window;

    static int idElement;

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
        /*for (int i = 0; i < database.LanguajesCount; i++)
            DisplayIdioma(i, database.idiomas[i]);*/
        if (GUILayout.Button("Confirm Edit"))
            AddContents();
    }
    private void DisplayIdioma(int index, Item item)
    {
        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name: " + item.name);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Content: ");
        //contents[index] = EditorGUILayout.TextArea(contents[index]);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();
    }

    private void AddContents()
    {
        Undo.RecordObject(database, "Content Added");
        /*for (int i = 0; i < database.LanguajesCount; i++)
            database.idiomas[i].EditContent(idElement, contents[i]);*/
        EditorUtility.SetDirty(database);
        window.Close();
    }
}