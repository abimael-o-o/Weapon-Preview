using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Diagnostics;
using UnityEditor;

public static class SaveSystem
{
    public static void SaveManager(Weapon wpn)
    {
        string path = Application.persistentDataPath + "/test.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        WeaponsData data = new WeaponsData(wpn);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Your data is saved!");
    }
    public static WeaponsData LoadManager()
    {
        string path = Application.persistentDataPath + "/test.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WeaponsData data = formatter.Deserialize(stream) as WeaponsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("That didn't work!");
            return null;
        }
    }
    public static int Tries()
    {
        int i = 1;
        if (i == 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}