using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class CanvasManager : MonoBehaviour
{
    public GameObject attButton, skillButt, objButt, sk1Butt, sk2Butt, sk3Butt;
    bool openAll, openSk = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAll()
    {
        if (!openAll)
        {
            attButton.SetActive(true); skillButt.SetActive(true); objButt.SetActive(true); openAll = true;
        }
        else if (openAll)
        {
            attButton.SetActive(false); skillButt.SetActive(false); objButt.SetActive(false); sk1Butt.SetActive(false); sk2Butt.SetActive(false); sk3Butt.SetActive(false); openAll = false;
        }
    }

    public void EndTurn()
    {

    }

    public void OpenSkills()
    {
        if (gameObject.CompareTag("MC") && !openSk)
        {
            sk1Butt.SetActive(true); sk2Butt.SetActive(true); sk3Butt.SetActive(true); openSk = true;
        }
        else if (!openSk)
        {
            sk1Butt.SetActive(true); sk2Butt.SetActive(true); openSk = true;
        }
        else if (openSk)
        {
            sk1Butt.SetActive(false); sk2Butt.SetActive(false); sk3Butt.SetActive(false); openSk = false;
        }
    }
}
