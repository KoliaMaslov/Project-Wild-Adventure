using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreScript : MonoBehaviour
{
    public OreData data;
    public int hitsGot = 0;
    [SerializeField] private OreSpawnScript spawnpoint;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickaxeHitSound;

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
        if (audioSource.clip == null) audioSource.clip = pickaxeHitSound;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickaxe"))
        {
            hitsGot++;
            audioSource.Play();
        }
    }
}
