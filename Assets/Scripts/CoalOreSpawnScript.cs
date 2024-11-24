using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalOreSpawnScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject orePrefab;
    public OreScript ore;
    private GameObject clone;
    public int hits;
    private bool isOnCooldown = false;
    void Start()
    {
        SpawnOre(orePrefab);
    }


    void Update()
    {
        if ((ore == null) && (!isOnCooldown))
        {
            ore = GetComponentInChildren<OreScript>();
        }
//        hits = ore.hitsGot;
        if (hits >= ore.data.HitsToDestroy)
        {
            ore.hitsGot = 0;
            hits = 0;
            StartCoroutine(DestroyOreCoroutine());
        }
/*        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(hits);
            Debug.Log(ore.hitsGot);
            Debug.Log(ore);
        }*/
    }

    private void SpawnOre(GameObject prefab)
    {
        clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
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
