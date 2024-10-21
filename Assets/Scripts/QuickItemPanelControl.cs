using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickItemPanelControl : MonoBehaviour
{
    public GameObject quickItemPanel;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            quickItemPanel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            quickItemPanel.SetActive(false);    
        }
    }
}
