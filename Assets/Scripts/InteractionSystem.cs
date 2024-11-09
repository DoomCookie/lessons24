using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    Transform gunPosition;
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
        if(Input.GetButtonDown("Interact") && Physics.Raycast(ray, out hit, 2f, layerMask))
        {
            GameObject newGun = hit.transform.gameObject;

            if(gunPosition.childCount != 0)
            {
                GameObject curGun = gunPosition.GetChild(0).gameObject;
                curGun.transform.SetParent(null);
                curGun.transform.position = newGun.transform.position;
                curGun.transform.rotation = newGun.transform.rotation;
                curGun.GetComponent<BoxCollider>().enabled = true;
                curGun.GetComponent<Shoot>().enabled = false;
                curGun.layer = LayerMask.NameToLayer("DropedGun");
            }

            newGun.transform.SetParent(gunPosition);
            newGun.transform.localPosition = Vector3.zero;
            newGun.transform.localRotation = Quaternion.identity;
            newGun.GetComponent<BoxCollider>().enabled = false;
            newGun.GetComponent<Shoot>().enabled = true;
            newGun.layer = LayerMask.NameToLayer("Gun");
        }
    }
}
