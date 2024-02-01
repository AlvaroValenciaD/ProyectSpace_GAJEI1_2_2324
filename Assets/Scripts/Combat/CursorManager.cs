using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject curMc, curP2, curP3, curP4, curE1, curE2, CurE3, CurE4, CurE5, CurE6, CurE7, CurE8;
    
    void Start()
    {
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>(); mesh.enabled = true;
        gameObject.transform.position = curMc.transform.position + new Vector3(-0.5f,0,0);
    }

    void Update()
    {
        
    }

    //void Turno (Pturn)
    //{
    //    cursorP = Pturn;
    //    gameObject.transform.position = cursorP.transform.position + new Vector3(-0.5f, 0, 0);
    //}
}
