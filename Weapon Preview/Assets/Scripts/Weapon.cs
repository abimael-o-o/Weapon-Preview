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

    private void Start()
    {
        int i = SaveSystem.Tries();
        if(i == 1)
        {
            loadData();
        }
        else
        {
            loadDefault();
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
        SaveSystem.SaveManager(this);
        SaveSystem.Tries();
    }
    public void loadData()
    {
        WeaponsData data = SaveSystem.LoadManager();
        assetPath = data.assetPath;
        str = data.weaponSkin;

        Material mat = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Material)) as Material;
        GetComponent<MeshRenderer>().material = mat;
        Debug.Log("Found the material:" + str);
    }
    public void loadDefault()
    {
        Debug.Log("Default Skin!");
    }
}