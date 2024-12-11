using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemMinecraft : MonoBehaviour
{
    [SerializeField]
    Transform handPosition;

    [SerializeField]
    LayerMask layerMask;

    InvertorySystem invertory;
    GameObject selectedItem;
    GameObject objectInHand;
    float delay = 0.4f;
    float startAnimation;

    GameObject tmpObject;
    // Start is called before the first frame update
    void Start()
    {
        tmpObject = null;
        invertory = GetComponent<InvertorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Cube")))
        {
            Animator animator = objectInHand.GetComponent<Animator>();
            if(animator && Time.realtimeSinceStartup - startAnimation > delay)
            {
                animator.Play("Idle");
                animator.Play("SwordBit");
                startAnimation = Time.realtimeSinceStartup;
            }
            //Destroy(hit.transform.gameObject);
        }

        if (selectedItem != invertory.GetSelectedItem())
        {
            Destroy(tmpObject);
            Destroy(objectInHand);
            selectedItem = invertory.GetSelectedItem();
        }
        if (!objectInHand)
        {
            objectInHand = Instantiate(invertory.GetSelectedItem(), handPosition);
            objectInHand.transform.localPosition = Vector3.zero;
            objectInHand.transform.localScale = objectInHand.transform.localScale / 2;
        }

        if (Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Cube")) &&
            Physics.OverlapBox(hit.transform.position + (hit.normal * hit.transform.localScale.x), 
                hit.transform.localScale * 0.45f).Length == 0 &&
                invertory.GetSelectedItem().tag == "Cube")
        {
            
            if(!tmpObject && invertory.GetSelectedItem())
            {
                
                tmpObject = Instantiate(invertory.GetSelectedItem());
                tmpObject.GetComponent<Animator>().enabled = false;
                
                Collider tmpCollider = tmpObject.GetComponent<Collider>();
                tmpCollider.enabled = false;
                MeshRenderer tmpMeshRenderer = tmpObject.GetComponent<MeshRenderer>();
                Material tmpMaterial = tmpMeshRenderer.material;
                Color tmpColor = tmpMaterial.color;
                tmpColor.a = 0.5f;
                tmpMaterial.color = tmpColor;
                tmpMeshRenderer.material = tmpMaterial;
            }
            Vector3 position = hit.transform.position + (hit.normal * hit.transform.localScale.x);
            Vector3Int point = Vector3Int.zero;
            point.x = Mathf.RoundToInt(position.x);
            point.y = Mathf.RoundToInt(position.y);
            point.z = Mathf.RoundToInt(position.z);
            Collider[] objects = Physics.OverlapBox(point, hit.transform.localScale * 0.45f);
            if (objects.Length == 0)
            {
                tmpObject.transform.position = point;
            }

        }
        else
        {
            Destroy(tmpObject);
            tmpObject = null;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            switch(objectInHand.tag)
            {
                case "Cube":
                {
                    Vector3 position = hit.transform.position + (hit.normal * hit.transform.localScale.x);
                    Vector3Int point = Vector3Int.zero;
                    point.x = Mathf.RoundToInt(position.x);
                    point.y = Mathf.RoundToInt(position.y);
                    point.z = Mathf.RoundToInt(position.z);
                    Collider[] objects = Physics.OverlapBox(point, hit.transform.localScale * 0.45f);
                    if (objects.Length == 0)
                    {
                        if (invertory.GetSelectedItem())
                        {
                            GameObject cube = Instantiate(invertory.GetSelectedItem());
                            cube.GetComponent<Animator>().enabled = false;
                            cube.transform.position = point;
                        }
                    }
                    break;
                }
                
            }

        }
    }
}
