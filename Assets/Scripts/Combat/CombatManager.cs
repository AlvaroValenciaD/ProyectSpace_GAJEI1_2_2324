using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public GameObject[] enemies, senemy;
    int numEnem;
    public List<Units> turnLane;
    public Units playingUnit;


    void Start()
    {
        EnemyGen();
        TimeLaneGenerator();
        LaneTimeSort();
        TurnAssignment();
        PlayerCursorManagement();
        EnemyTurn(playingUnit);
    }

    void Update()
    {
        
    }

    void TurnAssignment()
    {
        if (turnLane.Count > 0)
        {
            playingUnit = turnLane[0];
        }
        else
        {
            TimeLaneGenerator(); LaneTimeSort();
        }
       
    }

    public void Attack1()
    {
        Debug.Log("Bum martillazo en el ano");
        EndTurn();
    }

    public void Attack2()
    {
        Debug.Log("Bum martillazo en el duodeno");
        EndTurn();
    }

    void EnemyGen()
    {

        numEnem = Random.Range(1, 8);

        for (int i = 0; i <= numEnem; i++)
        {
            int typeEnem = Random.Range(0, enemies.Length);

            if (typeEnem == 0)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
            }
            else if (typeEnem == 1)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
            }
            else if (typeEnem == 2)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
            }

        }

    }

    void TimeLaneGenerator()
    {
        GameObject[] aux;
        aux = GameObject.FindGameObjectsWithTag("MC");
        for (int i = 0; i < aux.Length; i++)
        {
            turnLane.Add(aux[i].GetComponent<Units>());
        }
        

        aux = GameObject.FindGameObjectsWithTag("Pj");
        for (int i = 0; i < aux.Length; i++)
        {
            turnLane.Add(aux[i].GetComponent<Units>());
        }

        aux = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < aux.Length; i++)
        {
            turnLane.Add(aux[i].GetComponent<Units>());
        }


        //Debug.Log(turnLane.Count);
    }

    public void EnemyTurn(Units inputUnit)
    {
        if (playingUnit.CompareTag("Enemy"))
        {
            playingUnit.GetComponent<Enemy>().EnemyAttacking();
        }

    }

    public int DamageCalculator(Units attackingUnit, Units deffendingUnit)
    {
        int critRate = Random.Range(1, 101);

        if (critRate >= 5)
        {
            float dmgf = (attackingUnit.att * 1.5f) - deffendingUnit.def;
            int dmg = (int) dmgf;
            if (dmg <= 0)
            {
                dmg = 1;
            }
            Debug.Log("Hago " + dmg + " daño a " + deffendingUnit.name);
            return dmg;
        }
        else
        {
            int dmg = attackingUnit.att - deffendingUnit.def;

            if (dmg <= 0)
            {
                dmg = 1;
            }

            Debug.Log("Hago " + dmg + " daño a " + deffendingUnit.name);
            return dmg;
        }

    }

    public void EndTurn()
    {
        turnLane.Remove(playingUnit);
        LaneTimeSort();
        TurnAssignment();
        GameManager.current.canvasM.HpRefresh();
        GameManager.current.cursorM.CursorPjMovement(playingUnit);
        EnemyTurn(playingUnit);
    }

    void LaneTimeSort()
    {
        turnLane = turnLane.OrderByDescending(q => q.spe).ToList();
        //for (int i = 0; i < turnLane.Count; i++)
        //{
        //    Debug.Log(turnLane[i].spe + "   "+  turnLane[i].name);
        //}
        
    }

    void PlayerCursorManagement()
    {
        GameManager.current.cursorM.CursorPjMovement(turnLane[0].GetComponent<Pjs>());
    }

}
