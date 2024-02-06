using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public  CombatManager combatM;
    public  CanvasManager canvasM;
    public CursorManager cursorM;
    public List<Pjs> pjList;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
