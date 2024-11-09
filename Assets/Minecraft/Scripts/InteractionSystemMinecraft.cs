using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemMinecraft : MonoBehaviour
{
    [SerializeField]
    Transform handPosition;
    [SerializeField]
    List<GameObject> Cubes;
    [SerializeField]
    LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire2") && Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Cube")))
        {
            Destroy(hit.transform.gameObject);
        }
        if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray, out hit, 3f))
        {
            Vector3Int point = Vector3Int.zero;
            point.x = Mathf.RoundToInt(hit.point.x);
            point.y = Mathf.RoundToInt(hit.point.y);
            point.z = Mathf.RoundToInt(hit.point.z);
            GameObject cube = Instantiate(Cubes[0]);
            cube.transform.position = point;

        }
    }
}
