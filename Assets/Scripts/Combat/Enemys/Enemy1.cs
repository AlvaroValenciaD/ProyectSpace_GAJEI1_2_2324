using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject enemyTipe;
    public int hp, def, att, sp, vel, ID;

    void Start()
    {
        vel = vel + Random.Range(-2,+3);
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
