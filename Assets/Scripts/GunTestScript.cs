using UnityEngine;
using UnityEngine.Rendering;

public class GunTestScript : MonoBehaviour
{
    public int bullets;
    public static GunTestScript instance;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("Shot");
    }

    private void Awake()
    {
        instance = this;
    }
}
