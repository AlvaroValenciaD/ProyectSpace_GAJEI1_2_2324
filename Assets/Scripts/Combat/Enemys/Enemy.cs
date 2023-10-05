using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp, def, att, sp, vel;

    void Start()
    {
        
    }

    
    void Update()
    {
        Death();
    }

    void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
