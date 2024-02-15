using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CanvasManager : MonoBehaviour
{
    public GameObject attButton, skillButt, objButt, att1Butt, att2Butt, sk1Butt, sk2Butt, sk3Butt;
    bool openAll, openSk = false;

    void Start()
    {
        HpRefresh();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OpenAttacks(Units inputUnit)
    {
        inputUnit = GameManager.current.combatM.playingUnit;

        if (inputUnit.CompareTag("MC") && !openSk)
        {
            att1Butt.SetActive(true);
            att2Butt.SetActive(true);
            openSk = true;
        }
        else if (!openSk)
        {
            att1Butt.SetActive(true);
            openSk = true;
        }
        else if (openSk)
        {
            att1Butt.SetActive(false);
            att2Butt.SetActive(false); 
            openSk = false;
        }
    }

    public void OpenSkills(Units inputUnit)
    {
        inputUnit = GameManager.current.combatM.playingUnit;
        if (inputUnit.CompareTag("MC") && !openSk)
        {
            sk1Butt.SetActive(true);
            sk2Butt.SetActive(true);
            sk3Butt.SetActive(true);
            openSk = true;
        }
        else if (!openSk)
        {
            sk1Butt.SetActive(true);
            sk2Butt.SetActive(true);
            openSk = true;
        }
        else if (openSk)
        {
            sk1Butt.SetActive(false);
            sk2Butt.SetActive(false);
            sk3Butt.SetActive(false);
            openSk = false;
        }
    }
    
    public void CloseAll()
    {
        attButton.SetActive(false);
        skillButt.SetActive(false);
        objButt.SetActive(false);
        att1Butt.SetActive(false);
        att2Butt.SetActive(false);
        sk1Butt.SetActive(false);
        sk2Butt.SetActive(false);
        sk3Butt.SetActive(false);
        openAll = false;
    }
}
