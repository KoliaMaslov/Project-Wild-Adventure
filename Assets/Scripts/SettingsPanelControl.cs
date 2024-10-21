using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelControl : MonoBehaviour
{
    public GameObject settingsPanel;
    void Start()
    {
        
    }

    //close settings panel
    public void OnCloseBTClick()
    {
        settingsPanel.SetActive(false);
    }
}
