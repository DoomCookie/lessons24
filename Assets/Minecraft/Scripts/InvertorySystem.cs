using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class InvertorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] activeBar = new GameObject[10];
    GameObject[] inventory = new GameObject[10];
    int selectedIndex = 0;

    List<string> cubes;
    void Start()
    {
        cubes = new List<string>();
        for(int i = 0; i < inventory.Length; ++i)
        {
            activeBar[i] = null;
            inventory[i] = null;
        }

        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Minecraft/Prefabs" });
        foreach(string guid in guids)
        {
            print(guid);
            cubes.Add(AssetDatabase.GUIDToAssetPath(guid));
        }

        for(int i = 0; i < cubes.Count; ++i)
        {
            activeBar[i] = AssetDatabase.LoadAssetAtPath<GameObject>(cubes[i]);
            inventory[i] = AssetDatabase.LoadAssetAtPath<GameObject>(cubes[i]);
        }
    }

    public GameObject GetSelectedItem()
    {
        return activeBar[selectedIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory 1"))
        {
            selectedIndex = 0;
        }
        else if (Input.GetButtonDown("Inventory 2"))
        {
            selectedIndex = 1;
        }
        else if (Input.GetButtonDown("Inventory 3"))
        {
            selectedIndex = 2;
        }
    }
}
