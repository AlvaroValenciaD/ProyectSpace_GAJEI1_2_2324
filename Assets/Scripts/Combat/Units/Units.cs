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
            Debug.Log( name + " se muere");
            Death();
        }
    }
    void Death()
    {
        hp = 0;
        Destroy(this.gameObject);
    }

}
