using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReactionEnemy : HitReactionBase
{
    [SerializeField]
    Material deadEnemy;

    MeshRenderer _mr;
    // Start is called before the first frame update
    void Start()
    {
        _mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnHit()
    {
        int score = int.Parse(text.text.Split(' ')[1]);
        score += 5;
        text.text = $"Score: {score}";
        _mr.material = deadEnemy;
    }
}
