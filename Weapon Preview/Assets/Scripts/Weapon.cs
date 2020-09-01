using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public Material weaponMat;
    public string str;
    public string assetPath;
    public int FirstTime;
    public string id;

    private void Start()
    {
        id = this.name;
        FirstTime = PlayerPrefs.GetInt("FirstTime");
        if (FirstTime == 0)
        {
            loadDefault();
            Debug.Log("first run");
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            loadData();
            Debug.Log("welcome again!");
        }
    }
    public void getCurrentMaterial()
    {
        weaponMat = GetComponent<MeshRenderer>().material;
        str = weaponMat.name;
        str = str.Replace(" (Instance)", "");
    }

    public void saveData()
    {
        getCurrentMaterial();
        assetPath = "Assets/Materials/" + str + ".mat";
        SaveSystem.SaveManager(this, id);
    }
    public void loadData()
    { 
        WeaponsData data = SaveSystem.LoadManager(id);
        assetPath = data.assetPath;
        str       = data.weaponSkin;

        Material mat = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Material)) as Material;
        GetComponent<MeshRenderer>().material = mat;
        Debug.Log("Found the material:" + str);
    }
    public void loadDefault()
    {
        saveData();
        Debug.Log("Default Skin!");
    }
}