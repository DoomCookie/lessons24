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
        if(Physics.Raycast(ray, out hit, 2f, layerMask))
        {
            if(Input.GetButtonDown("Interact"))
            {
                GameObject curGun = gunPosition.GetChild(0).gameObject;
                curGun.transform.SetParent(null);
                GameObject newGun = hit.transform.gameObject;
                curGun.transform.position = newGun.transform.position;
                curGun.transform.rotation = newGun.transform.rotation;
                newGun.transform.SetParent(gunPosition);
                newGun.transform.localPosition = Vector3.zero;
                newGun.transform.localRotation = Quaternion.identity;
                newGun.GetComponent<BoxCollider>().enabled = false;
                curGun.GetComponent<BoxCollider>().enabled = true;
                newGun.GetComponent<Shoot>().enabled = true;
                curGun.GetComponent<Shoot>().enabled = false;
                newGun.layer = LayerMask.NameToLayer("Gun");
                curGun.layer = LayerMask.NameToLayer("DropedGun");
            }
        }
    }
}
