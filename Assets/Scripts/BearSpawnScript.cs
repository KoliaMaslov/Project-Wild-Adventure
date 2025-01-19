using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawnScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bearPrefab;
    private BearScript bear;
    private GameObject clone;
    private bool isOnCooldown;

    void Start()
    {
        SpawnBear(bearPrefab);
    }

    void Update()
    {
        
    }

    private void SpawnBear(GameObject bearPrefab)
    {
        clone = Instantiate(bearPrefab, spawnPoint.position, Quaternion.identity);
        clone.transform.parent = spawnPoint.transform;
    }
}
