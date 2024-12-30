using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    //    [SerializeField] GunTestScript gun;
    public GameObject cube;
    private GunTestScript gun;
    void Start()
    {
         cube = GameObject.Find("TestGuin");
         cube.TryGetComponent<GunTestScript>(out gun);
       // gun = GunTestScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseDown();
        }
    }

    public void OnMouseDown()
    {
        gun.Shoot();
    }
}
