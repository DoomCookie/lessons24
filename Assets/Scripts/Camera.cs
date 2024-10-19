using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    float _localRoation = 0;

    [SerializeField]
    float cameraSpeed = 1;

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
            _localRoation += move_y * cameraSpeed * Time.deltaTime;
            _localRoation = Mathf.Clamp(_localRoation, -80, 80);

            Vector3 rotation = new Vector3(_localRoation, 0, 0);
            transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}
