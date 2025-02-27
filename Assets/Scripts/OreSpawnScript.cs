using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawnScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject orePrefab;
    [SerializeField] private InventoryControl inventory;
    public OreScript ore;
    private GameObject clone;
    public int hits;
    public int hitsNeededToDestroy;
    private bool isOnCooldown = false;
    public string currentOre;
    void Start()
    {
        SpawnOre(orePrefab);
        inventory.inventoryPanel.SetActive(true);
        inventory.inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (ore == null && !isOnCooldown)
        {
            ore = GetComponentInChildren<OreScript>();
        }
        if (hits >= hitsNeededToDestroy)
        {
            ore.hitsGot = 0;
            hits = 0;
            StartCoroutine(DestroyOreCoroutine());
            inventory.AddItem(currentOre);
        }
    }

    private void SpawnOre(GameObject orePrefab)
    {
        clone = Instantiate(orePrefab, spawnPoint.position, Quaternion.identity);
        clone.transform.parent = spawnPoint.transform;
    }

    IEnumerator DestroyOreCoroutine()
    {
        isOnCooldown = true;
        Destroy(clone);
        yield return new WaitForSeconds(5);
        SpawnOre(orePrefab);
        isOnCooldown = false;
    }
}
