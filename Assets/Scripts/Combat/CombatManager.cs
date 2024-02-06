using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public GameObject[] enemies, senemy;
    int numEnem;
    public List<Units> turnLane;
    Units playingUnit;


    void Start()
    {
        EnemyGen();
        TimeLaneGenerator();
        LaneTimeSort();
        TurnAssignment();
        PlayerCursorManagement();
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

    public void EndTurn()
    {
        turnLane.Remove(playingUnit);
        LaneTimeSort();
        TurnAssignment();
        GameManager.current.cursorM.CursorPjMovement(turnLane[0].GetComponent<Pjs>());
    }

    void LaneTimeSort()
    {
        turnLane = turnLane.OrderByDescending(q => q.spe).ToList();
        for (int i = 0; i < turnLane.Count; i++)
        {
            Debug.Log(turnLane[i].spe + "   "+  turnLane[i].name);
        }
        
    }

    void PlayerCursorManagement()
    {
        GameManager.current.cursorM.CursorPjMovement(turnLane[0].GetComponent<Pjs>());
    }

}
