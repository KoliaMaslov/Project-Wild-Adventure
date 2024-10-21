using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    void Start()
    {
        
    }

    //close inventory panel
    public void OnCloseBTClick()
    {
        inventoryPanel.SetActive(false);
    }
}
