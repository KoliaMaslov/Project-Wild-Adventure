using UnityEngine;

public class GameEndBSPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject gameEndBSPanel;
    [SerializeField] private BasicPanelControl _basicPanel;
    [SerializeField] private SpawnMenu _spawnMenu;
    [SerializeField] private CameraController _cameraController;
    private GameObject playerClone;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnRespawnBTClick()
    {
        if (!_spawnMenu.isSpawned)
        {
            playerClone = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            _spawnMenu.isSpawned = true;
            _basicPanel.InitializeMainPlayerScript(playerClone.gameObject.GetComponent<PlayerMainScript>());
            _basicPanel.InitializePlayerMovementScript(playerClone.gameObject.GetComponent<PlayerMovement>());
            _basicPanel.InitializePlayerObj(playerClone);
            _cameraController.InitializeMainPlayerScript(playerClone.gameObject.GetComponent<PlayerMainScript>());
            _cameraController.InitializePlayerObj(playerClone);
        }
        _basicPanel.health = 100;
        _basicPanel.HealthTextUpdate(_basicPanel.health);
        gameEndBSPanel.SetActive(false);
    }
}
