using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject losePanel, winPanel;
    public int totalNPCs, homeNPCs;
    private InfectionBar iB;
    
    void Awake()
    {
        #if UNITY_EDITOR
            QualitySettings. vSyncCount = 0; // VSync must be disabled.
            Application. targetFrameRate = 60;
        #endif
    }

    void Start()
    {
        iB = GameObject.FindGameObjectWithTag("InfectionBar").GetComponent<InfectionBar>();
        homeNPCs = 0;
    }

    void Update()
    {
        if (iB.CheckLoseCond())
            ActivateLoseState();

        if (CheckWinCond())
            ActivateWinState();
    }

    public void NPCSentHome()
    {
        homeNPCs += 1;
        //iB.DecrementInfectionLevel();
    }

    bool CheckWinCond()
    {
        return (homeNPCs == totalNPCs);
    }

    void ActivateWinState()
    {
        winPanel.SetActive(true);
    }

    void ActivateLoseState()
    {
        losePanel.SetActive(true);
    }
}
