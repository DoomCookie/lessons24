using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    float speedUp = 1;
    [SerializeField]
    float jump_force = 3;
    Rigidbody rb;
    [SerializeField]
    GroundChecker gc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Run"))
        {
            speedUp = 2;
        }
        if(Input.GetButtonUp("Run"))
        {
            speedUp = 1;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = transform.forward * vertical + transform.right * horizontal;
        dir = dir.normalized * speed * speedUp * Time.deltaTime;
        rb.MovePosition(transform.position + dir);
        //transform.position += dir;


        if(gc.isGround && Input.GetButtonDown("Jump"))
        {
            Vector3 jump_v = new Vector3(0, jump_force, 0);
            rb.AddForce(jump_v);
        }
        
    }
}
