using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    enum Rotation
    {
        X,
        Y,
        Z
    }
    // Start is called before the first frame update
    [SerializeField]
    Rotation rot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (rot == Rotation.Y)
        {
            float move_x = Input.GetAxis("Mouse X");
            Vector3 rotation = new Vector3(0, move_x, 0);
            transform.Rotate(rotation);
        }
        else if(rot == Rotation.X)
        {
            float move_y = Input.GetAxis("Mouse Y");
            Vector3 rotation = new Vector3(move_y, 0, 0);
            transform.Rotate(rotation);
        }
    }
}
