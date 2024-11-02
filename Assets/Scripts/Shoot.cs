using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawn;
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    int size = 1;
    [SerializeField]
    int speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject blt = Instantiate(bullet);
            blt.transform.localScale *= size;
            blt.transform.position = bulletSpawn.transform.position;
            blt.transform.rotation = bulletSpawn.transform.rotation;
            Rigidbody rbBullet = blt.GetComponent<Rigidbody>();
            rbBullet.AddForce(blt.transform.forward * speed, ForceMode.Impulse);
            
        }
    }
}
