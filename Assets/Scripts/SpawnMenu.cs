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
    private GameObject playerClone;

    [SerializeField] private BasicPanelControl _basicPanelScript;
    [SerializeField] private CameraController _cameraController;

    void Start()
    {
        
    }

    public void OnSpawnBTClick()
    {
        if (!isSpawned)
        {
            playerClone = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
            isSpawned = true;
            _basicPanelScript.InitializeMainPlayerScript(playerClone.gameObject.GetComponent<PlayerMainScript>());
            _basicPanelScript.InitializePlayerMovementScript(playerClone.gameObject.GetComponent<PlayerMovement>());
            _basicPanelScript.InitializePlayerObj(playerClone);
            _cameraController.InitializeMainPlayerScript(playerClone.gameObject.GetComponent<PlayerMainScript>());
            _cameraController.InitializePlayerObj(playerClone);
        }
        spawnPanel.SetActive(false);
        basicPanel.SetActive(true);
    }
}
