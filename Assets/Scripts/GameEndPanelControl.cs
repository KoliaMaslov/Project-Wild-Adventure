using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject gameEndPanel;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnCloseBTClick()
    {
        gameEndPanel.SetActive(false);
    }
}
