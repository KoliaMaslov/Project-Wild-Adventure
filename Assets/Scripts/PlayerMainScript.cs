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
    public GameObject player;
    public GameObject pickaxePrefab;
    private GameObject pickaxe;
    public GameObject axePrefab;
    private GameObject axe;
    public Transform itemHolder;
    void Start()
    {
        LockCursor();
        itemHolder = player.transform.Find("ItemHolder");
    }

    void Update()
    {
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
        if (itemHolder)
        {
            if (isHandfree && !isPickaxeEquipped)
            {
                Vector3 pos = itemHolder.position;
 //               Debug.Log(pos);
                pickaxe = Instantiate(pickaxePrefab, pos, player.transform.rotation, player.transform);
//                pickaxe.transform.parent = player.transform;
                isHandfree = false;
                isPickaxeEquipped = true;
            }
            else if (isPickaxeEquipped)
            {
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
                axe = Instantiate(axePrefab, pos, player.transform.rotation, player.transform);
                axe.transform.Rotate(0f, 90f, 0f);
//                axe.transform.parent = player.transform;
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
}
