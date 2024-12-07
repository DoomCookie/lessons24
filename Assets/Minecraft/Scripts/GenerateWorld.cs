using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField]
    GameObject cube,player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -100; i < 100; ++i)
        {
            for(int j = -100; j < 100; ++j)
            {
                GameObject tmp = Instantiate(cube, transform);
                tmp.transform.position = new Vector3(i, 1, j);
            }
        }
        GameObject playerObj = Instantiate(player);
        playerObj.transform.position = new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
