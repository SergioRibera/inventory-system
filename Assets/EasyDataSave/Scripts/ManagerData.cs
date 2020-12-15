using System;
using UnityEngine;
using EasyDataSave;

public static class ManagerData
{
    static string _path = Application.persistentDataPath + "/";
    static string _key = "Kalskdja-321a$&q3321*}'";

    public static bool Exist(Type type) => SaveDataManager.Exist(type, _path);

    public static object Save(object data, bool savePrivates = false) => SaveDataManager.Save(data, _path, _key, savePrivates);
    public static T Save<T>(this object o, bool savePrivates = false) => (T)Save(o, savePrivates);

    public static T Load<T>(bool loadPrivates = false) => SaveDataManager.Load<T>(_path, _key, loadPrivates);
    public static T Load<T>(this object o, bool loadPrivates = false) {
        o = Load<T>(loadPrivates);
        return (T)o;
    }
}
