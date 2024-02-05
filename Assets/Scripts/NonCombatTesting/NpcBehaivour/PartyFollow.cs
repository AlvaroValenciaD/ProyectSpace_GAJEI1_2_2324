using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyFollow : MonoBehaviour
{
    public GameObject player;
    public  GameObject thisGameObject;
    public float speed;
    public float distanciaDeSeparacion;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist > distanciaDeSeparacion)
        {
            this.transform.position = Vector3.MoveTowards(thisGameObject.transform.position, player.transform.position, speed);
        }
    
    }
}
