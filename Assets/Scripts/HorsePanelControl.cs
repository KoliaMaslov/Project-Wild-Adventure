using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePanelControl : MonoBehaviour
{
    public GameObject horsePanel;
    void Start()
    {
        
    }

    //close horse panel
    public void OnCloseBTClick()
    {
        horsePanel.SetActive(false);
    }
}
