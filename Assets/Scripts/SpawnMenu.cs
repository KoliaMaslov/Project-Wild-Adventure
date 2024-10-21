using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMenu : MonoBehaviour
{
    public GameObject spawnPanel;
    public GameObject basicPanel;

    void Start()
    {
        
    }

    public void OnSpawnBTClick()
    {
        spawnPanel.SetActive(false);
        basicPanel.SetActive(true);
    }
}
