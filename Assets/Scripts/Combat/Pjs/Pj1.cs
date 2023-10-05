using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj1 : MonoBehaviour
{
    public int hp, att, def, sp, vel;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            Attack();
        }
    }

    void Attack()
    {
        
    }

    void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
