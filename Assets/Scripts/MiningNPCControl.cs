using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningNPCControl : MonoBehaviour
{
    public GameObject shopPanel;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //close shop panel
    public void OnCloseBTClick()
    {
        shopPanel.SetActive(false);
    }
}
