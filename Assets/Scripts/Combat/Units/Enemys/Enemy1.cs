using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    

    private void Awake()
    {
        spe = spe + Random.Range(-2, +3);
    }
    void Start()
    {
        gameObject.name = "Enemy1" + " ID " + id.ToString();
    }

}
