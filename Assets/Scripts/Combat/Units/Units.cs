using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Units : MonoBehaviour
{
    public int hp, hpMax, att, def, spD, spe;

    private void Update()
    {
        if (hp<=0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }

}
