using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitReactionBase : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        throw new NotImplementedException("ƒанный класс €вл€етс€ базовым и не может быть использован");
    }

    public virtual void OnHit()
    {
        throw new NotImplementedException("ƒанный класс €вл€етс€ базовым и в нем не реализован этот метод");
    }

}
