using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject curE1, curE2, CurE3, CurE4, CurE5, CurE6, CurE7, CurE8;
    public GameObject pjCur, enemCur;
    
    void Start()
    {
        CursorPjMovement(GameManager.current.combatM.turnLane[0].GetComponent<Pjs>());
        CursorMeshOn(pjCur);
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

    public void CursorPjMovement(Pjs inputPj)
    {

        pjCur.transform.position = inputPj.curPosition.transform.position;

    }

     void CursorResetPosition(GameObject inputGo)
    {
        inputGo.transform.position = new Vector3(0, 0, 0);
    }

}
