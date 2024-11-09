using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject Wall;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float CellWidth, CellHeight;

    [SerializeField]
    string mapPath;
    string[] map;

    Dictionary<char, GameObject> mapper;

    // Start is called before the first frame update
    void Start()
    {
        mapper = new Dictionary<char, GameObject> { { '#', Wall }, { '@', Player }, { '.', null } };
        StreamReader sr = new StreamReader(mapPath);
        map = sr.ReadToEnd().Split("\r\n");
        for( int i = 0; i < map.Length; ++i)
        {
            for(int j = 0; j < map[i].Length; ++j)
            {
                GameObject obj = mapper[map[i][j]];
                if(obj is not null)
                {
                    GameObject curObj;
                    Vector3 position = Vector3.zero;
                    position.x = j * CellWidth;
                    position.z = i * CellHeight;
                    if (map[i][j] != '@')
                    {
                        curObj = Instantiate(obj, transform);
                    }
                    else
                    {
                        curObj = obj;
                        position = transform.position + position;
                    }
                    
                    curObj.transform.localPosition = position;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
