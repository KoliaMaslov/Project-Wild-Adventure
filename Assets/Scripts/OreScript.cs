using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreScript : MonoBehaviour
{
    public OreData data;
    public int hitsGot = 0;
    [SerializeField] private OreSpawnScript spawnpoint;

    void Start()
    {
        if (spawnpoint == null)
        {
            spawnpoint = GetComponentInParent<OreSpawnScript>();
            spawnpoint.hitsNeededToDestroy = data.HitsToDestroy;
            spawnpoint.currentOre = data.Name;
        }
    }


    void Update()
    {
        spawnpoint.hits = hitsGot;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickaxe"))
        {
            hitsGot++;
            Debug.Log(hitsGot);
        }
    }
}
