using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Transform tp_point_pisition;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = tp_point_pisition.position;
    }

}
