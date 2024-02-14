using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Units
{
    public int id;

    public void EnemyAttacking()
    {
        int n = Random.Range(0,4);
        Pjs pjAttacked = GameManager.current.pjList[n];

        pjAttacked.hp = pjAttacked.hp - GameManager.current.combatM.DamageCalculator(this,pjAttacked);

        GameManager.current.combatM.EndTurn();
    }
}
