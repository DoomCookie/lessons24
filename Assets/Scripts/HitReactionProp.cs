using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HitReactionProp : HitReactionBase
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public override void OnHit()
    {
        int score = int.Parse(text.text.Split(' ')[1]);
        score += 1;
        text.text = $"Score: {score}";
        _rb.useGravity = true;
        _rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }
}
