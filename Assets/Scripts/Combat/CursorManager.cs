using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject curE1, curE2, CurE3, CurE4, CurE5, CurE6, CurE7, CurE8;
    public GameObject pjCur, enemCur;
    
    void Start()
    {
        CursorPjMovement(GameManager.current.combatM.playingUnit);
    }

    void Update()
    {
        
    }

    void CursorMeshOn(GameObject inputGo)
    {
        SpriteRenderer sprite= inputGo.GetComponent<SpriteRenderer>();
        sprite.enabled = true;
    }

    void CursorMeshOff(GameObject inputGo)
    {
        SpriteRenderer sprite = inputGo.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    public void CursorPjMovement(Units inputUnit)
    {

        if (inputUnit.CompareTag("Pj") == true || inputUnit.CompareTag("MC") == true)
        {
            CursorMeshOn(pjCur);
            pjCur.transform.position = inputUnit.GetComponent<Pjs>().curPosition.transform.position;
        }
        else if (inputUnit.CompareTag("Enemy") == true)
        {
            CursorMeshOff(pjCur);
        }
        

    }

     void CursorResetPosition(GameObject inputGo)
    {
        inputGo.transform.position = new Vector3(0, 0, 0);
    }

}
