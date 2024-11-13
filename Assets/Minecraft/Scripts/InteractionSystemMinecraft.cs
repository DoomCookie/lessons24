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
        if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Cube")))
        {
            Vector3 position = hit.transform.position + (hit.normal * hit.transform.localScale.x);
            Vector3Int point = Vector3Int.zero;
            point.x = Mathf.RoundToInt(position.x);
            point.y = Mathf.RoundToInt(position.y);
            point.z = Mathf.RoundToInt(position.z);
            Collider[] objects = Physics.OverlapBox(point, hit.transform.localScale * 0.45f);
            if (objects.Length == 0)
            {
                GameObject cube = Instantiate(Cubes[0]);
                cube.transform.position = point; 
            }

        }
    }
}
