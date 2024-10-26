using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float _timeDelta = 0;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeDelta += Time.deltaTime;

        transform.LookAt(transform.position + _rb.velocity);
        if (_timeDelta > 10) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        HitReactionBase hr = go.GetComponent<HitReactionBase>();
        if (hr)
        {
            hr.OnHit();
        }
        Destroy(gameObject);
    }
}
