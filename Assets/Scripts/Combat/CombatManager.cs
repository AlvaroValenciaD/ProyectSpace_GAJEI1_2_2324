using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject[] enemies, senemy;
    int numEnem;
    public List<GameObject> turnLane;


    void Start()
    {
        EnemyGen(); TimeLaneGenerator();
    }

    void Update()
    {
        
    }

    void TurnLane()
    {

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
        
        numEnem = Random.Range(1, 9);

        for (int i = 0; i <= numEnem; i++)
        {
            int typeEnem = Random.Range(0, enemies.Length);
            if (typeEnem == 0)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
                enemPf.GetComponent<Enemy1>().ID = i+1;
            }
            if (typeEnem == 1)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
                enemPf.GetComponent<Enemy2>().ID = i+1;
            }
            if (typeEnem == 2)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
                enemPf.GetComponent<Enemy3>().ID = i+1;
            }

        }

    }

    void TimeLaneGenerator()
    {
        GameObject[] aux;
        aux = GameObject.FindGameObjectsWithTag("MC");
        for (int i = 0; i < aux.Length; i++)
        {
            turnLane.Add(aux[i]);
        }
        aux = GameObject.FindGameObjectsWithTag("Pj");
        for (int i = 0; i < aux.Length; i++)
        {
            turnLane.Add(aux[i]);
        }
        aux = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < aux.Length; i++)
        {
            turnLane.Add(aux[i]);
        }

        Debug.Log(turnLane.Count);
    }

    void EndTurn()
    {

    }

    void LaneTimeSort()
    {
    }

}
