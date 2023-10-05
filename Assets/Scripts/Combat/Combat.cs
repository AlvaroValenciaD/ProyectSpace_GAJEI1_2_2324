using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject[] enemies, senemy;
    int numEnem;
    void Start()
    {
        numEnem = Random.Range(1, 9);

        for (int i = 0; i <= numEnem; i++)
        {
            int typeEnem = Random.Range(0, enemies.Length);
            GameObject enemPf = Instantiate(enemies[typeEnem], senemy[i].transform.position, Quaternion.identity);
        }
        // Aqui hariamos un for para asignar cada gameobject a un enem
        //for (int i = 0; i < numEnem; i++)
        //{
        //}


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnLane()
    {

    }
}
