using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearSpawnScript : MonoBehaviour
{
    public Transform spawnPoint;
    [SerializeField] private GameObject bearPrefab;
    [SerializeField] private BearScript bear;
    [SerializeField] private InventoryControl inventory;
    [SerializeField] private BasicPanelControl basicPanel;
    private GameObject clone;
    private bool isOnCooldown = false;
    private bool isBearSpawned = false;
    private float respawnTime = 5f;

    void Start()
    {
        SpawnBear(bearPrefab);
    }

    void Update()
    {
        if (bear == null && isBearSpawned) bear = GetComponentInChildren<BearScript>();
        if (bear.health <= 0 && !isOnCooldown) StartCoroutine(DieAndRespawn(respawnTime));
    }

    private void SpawnBear(GameObject bearPrefab)
    {
        clone = Instantiate(bearPrefab, spawnPoint.position, Quaternion.identity);
        clone.transform.parent = spawnPoint.transform;
        bear = clone.gameObject.GetComponent<BearScript>();
        isBearSpawned = true;
        bear.InitializeBasicPanelScript(basicPanel);
    }

    private IEnumerator DieAndRespawn(float time)
    {
        isOnCooldown = true;
        bear.ResetTarget();
        Destroy(clone);
        inventory.AddItem("Raw Steak");
        inventory.AddItem("Raw Ham");
        isBearSpawned = false;
        yield return new WaitForSeconds(time);
        SpawnBear(bearPrefab);
        isOnCooldown = false;
    }
}
