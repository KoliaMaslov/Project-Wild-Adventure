using UnityEngine;

public class GameEndBSPanelControl : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject gameEndBSPanel;
    [SerializeField] private BasicPanelControl basicPanel;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnRespawnBTClick()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        gameEndBSPanel.SetActive(false);
        basicPanel.health = 100;
        basicPanel.HealthTextUpdate(basicPanel.health);
    }
}
