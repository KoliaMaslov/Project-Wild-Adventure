using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPanelControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject horsePanel;
    public GameObject settingsPanel;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //open inventory panel
    public void OnInventoryBTClick()
    {
        inventoryPanel.SetActive(true);
    }

    //open horse panel
    public void OnHorseBTClick()
    {
        horsePanel.SetActive(true);
    }
    
    //open settings panel
    public void OnSettingsBTClick()
    {
        settingsPanel.SetActive(true);
    }
}
