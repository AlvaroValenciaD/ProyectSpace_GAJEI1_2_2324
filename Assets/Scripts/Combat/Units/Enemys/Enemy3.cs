using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{

    private void Awake()
    {
        spe = spe + Random.Range(-3, +4);
    }
    void Start()
    {
        gameObject.name = "Enemy3" + " ID " + id.ToString();
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
