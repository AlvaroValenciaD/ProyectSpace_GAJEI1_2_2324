using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CanvasManager : MonoBehaviour
{
    public GameObject attButton, skillButt, objButt, sk1Butt, sk2Butt, sk3Butt;
    bool openAll, openSk = false;
    void Start()
    {
        HpRefresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurnCanvas()
    {
        GameManager.current.combatM.EndTurn();
        CloseAll();
    }

    public void Attack1Canvas()
    {
        GameManager.current.combatM.Attack1();
        CloseAll();
    }

    public void Attack2Canvas()
    {
        GameManager.current.combatM.Attack2();
        CloseAll();
    }

    public void HpRefresh()
    {
        foreach (Pjs hpBar in GameManager.current.pjList)
        {
            HpBars(hpBar);
        }
    }


    void HpBars(Pjs inputPj)
    {
        inputPj.hpBar.GetComponent<Slider>().maxValue = inputPj.hpMax;
        inputPj.hpBar.GetComponent<Slider>().value = inputPj.hp;
        inputPj.hpBar.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = inputPj.hp.ToString() + "/" + inputPj.hpMax.ToString();
    }
    public void OpenAll()
    {
        if (!openAll)
        {
            attButton.SetActive(true); skillButt.SetActive(true); objButt.SetActive(true); openAll = true;
        }
        else if (openAll)
        {
            CloseAll();
        }
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
    
    void CloseAll()
    {
        attButton.SetActive(false); skillButt.SetActive(false); objButt.SetActive(false); sk1Butt.SetActive(false); sk2Butt.SetActive(false); sk3Butt.SetActive(false); openAll = false;
    }
}
