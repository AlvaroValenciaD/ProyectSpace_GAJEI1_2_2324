using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManager : MonoBehaviour
{
    public GameObject[] enemies, senemy;
    int numEnem, playerAttack;
    public List<Units> turnLane;
    public Units playingUnit;
    public bool attackingMode;
    Outline outline;
    bool outlineOn;


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
        if (attackingMode)
        {
            if (playerAttack == 0)
            {
                PlayerAttack(playerAttack);
            }
            if (playerAttack == 1)
            {
                PlayerAttack(playerAttack);
            }
        }
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

    void PlayerAttack(int attType)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                outline = hit.transform.GetComponent<Outline>();
                outline.enabled = true;
                outlineOn = true;

                if (Input.GetMouseButton(0))
                {
                    outline.enabled = false;
                    hit.transform.GetComponent<Enemy>().hp = hit.transform.GetComponent<Enemy>().hp - (DamageCalculator(playingUnit, hit.transform.GetComponent<Units>()) + (attType * 5));
                    Debug.Log(playingUnit.name + " hace " + (DamageCalculator(playingUnit, hit.transform.GetComponent<Units>()) + (attType * 5)) + " de daño a " + hit.transform.name);
                    EndTurn();
                    
                }
            }
            else if (!hit.transform.CompareTag("Enemy") && outlineOn)
            {
                outline.enabled = false;
                outlineOn = false;
            }
        }
    }

    public void Attack1()
    {
        attackingMode = true;
        playerAttack = 0;
    }

    public void Attack2()
    {
        attackingMode = true;
        playerAttack = 1;
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
                enemPf.GetComponent<Enemy>().id = i + 1;
            }
            else if (typeEnem == 1)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
                enemPf.GetComponent<Enemy>().id = i + 1;
            }
            else if (typeEnem == 2)
            {
                GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
                enemPf.GetComponent<Enemy>().id = i + 1;
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
            if (attackingUnit.CompareTag("Enemy"))
            {
                Debug.Log(attackingUnit.name + " Hace " + dmg + " daño a " + deffendingUnit.name);
            }
            
            return dmg;
        }
        else
        {
            int dmg = attackingUnit.att - deffendingUnit.def;

            if (dmg <= 0)
            {
                dmg = 1;
            }
            if (attackingUnit.CompareTag("Enemy"))
            {
                Debug.Log(attackingUnit.name + " Hace " + dmg + " daño a " + deffendingUnit.name);
            }
            return dmg;
        }

    }

    public void EndTurn()
    {
        attackingMode = false;
        turnLane.Remove(playingUnit);
        LaneTimeSort();
        TurnAssignment();
        GameManager.current.canvasM.HpRefresh();
        GameManager.current.canvasM.CloseAll();
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
