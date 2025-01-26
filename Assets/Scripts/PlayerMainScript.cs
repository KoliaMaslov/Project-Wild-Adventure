using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    public bool isLocked = true;
    public bool isHandfree = true;
    public bool isPickaxeEquipped = false;
    public bool isAxeEquipped = false;
    public bool isGunEquipped = false;
    public GameObject player;
    public GameObject pickaxePrefab;
    private GameObject pickaxe;
    public GameObject axePrefab;
    private GameObject axe;
    public Transform itemHolder;
    public GameObject gunPrefab;
    private GameObject gun;
    void Start()
    {
        LockCursor();
        itemHolder = player.transform.Find("ItemHolder");
    }

    void Update()
    {
        //if (player == null) player = GameObject.FindWithTag("Player");
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isLocked)
            {
                UnlockCursor();
            }
            else if (!isLocked)
            {
                LockCursor();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //TakePickaxe();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //TakeAxe();
        }
        
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isLocked = false;
    }

    public void TakePickaxe()
    {
        if(itemHolder == null) itemHolder = player.transform.Find("ItemHolder");
        if (itemHolder)
        {
            if (isHandfree && !isPickaxeEquipped)
            {
                Vector3 pos = itemHolder.position;
                pickaxe = Instantiate(pickaxePrefab, pos, player.transform.rotation, player.transform);
                isHandfree = false;
                isPickaxeEquipped = true;
            }
            else if (isPickaxeEquipped)
            {
                Debug.Log("3etap");
                Destroy(pickaxe);
                isHandfree = true;
                isPickaxeEquipped = false;
            }
        }
    }

    public void TakeAxe()
    {
        if (itemHolder)
        {
            if (isHandfree && !isAxeEquipped)
            {
                Vector3 pos = itemHolder.position;
                axe = Instantiate(axePrefab, pos, transform.rotation, player.transform);
                axe.transform.Rotate(0f, 0f, 0f);
                isHandfree = false;
                isAxeEquipped = true;
            }
            else if (isAxeEquipped)
            {
                Destroy(axe);
                isHandfree = true;
                isAxeEquipped = false;
            }
        }
    }

    public void TakeGun()
    {
        if (itemHolder)
        {
            if (isHandfree && !isGunEquipped)
            {
                Vector3 pos = itemHolder.position;
                gun = Instantiate(gunPrefab, pos, transform.rotation, player.transform);
                gun.transform.Rotate(0f, 180f, 0f);
                isHandfree = false;
                isGunEquipped = true;
            }
            else if (isGunEquipped)
            {
                Destroy(gun);
                isHandfree = true;
                isGunEquipped = false;
            }
        }
    }
}
