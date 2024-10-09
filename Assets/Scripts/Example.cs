using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    float x_min, x_max, y_min, y_max;
    Vector3 speed_vec;
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        x_min = transform.position.x;
        y_min = transform.position.y;
        x_max = x_min + 5;
        y_max = y_min + 5;
        speed_vec = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.x < x_max && pos.y < y_min && speed_vec.y < 0)
        {
            speed_vec = new Vector3(speed, 0, 0);
        }
        else if(pos.x > x_max && pos.y < y_max && speed_vec.x > 0)
        {
            speed_vec = new Vector3(0, speed, 0);
        }
        else if(pos.x > x_max && pos.y > y_max && speed_vec.y > 0)
        {
            speed_vec = new Vector3(-speed, 0, 0);
        }
        else if(pos.x < x_min && pos.y > y_min && speed_vec.x < 0)
        {
            speed_vec = new Vector3(0, -speed, 0);
        }
        pos += speed_vec * Time.deltaTime;
        transform.position = pos;
    }
}
