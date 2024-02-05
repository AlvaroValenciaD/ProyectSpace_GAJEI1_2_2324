using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{

    private void Awake()
    {
        spe = spe + Random.Range(-1, +2);
    }
    void Start()
    {
        gameObject.name = "Enemy2" + " ID " + id.ToString();
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
