using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMenu : MonoBehaviour
{
    public GameObject spawnPanel;
    public GameObject basicPanel;
    public GameObject playerPrefab;
    public bool isSpawned = false;
    public Transform spawnPosition;

    void Start()
    {
        
    }

    public void OnSpawnBTClick()
    {
        if (!isSpawned)
        {
            Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
            isSpawned = true;
        }
        spawnPanel.SetActive(false);
        basicPanel.SetActive(true);
    }
}
