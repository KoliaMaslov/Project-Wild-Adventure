using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicPanelControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject horsePanel;
    public GameObject settingsPanel;

    [SerializeField] private PlayerMainScript player;
    public GameObject temp;

    public Image[] equippedItems;
    public bool[] isCellOccupied = new bool[6];
    public string[] equippedItemType = new string[6];
    void Start()
    {
        for (int c = 0; c < isCellOccupied.Length; c++) isCellOccupied[c] = false;
        temp = GameObject.FindGameObjectWithTag("Player");
        temp.TryGetComponent<PlayerMainScript>(out player);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isCellOccupied[0])
        {
            SwitchItemType(equippedItemType[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isCellOccupied[1])
        {
            SwitchItemType(equippedItemType[1]);
        }
    }

    //open inventory panel
    public void OnInventoryBTClick()
    {
        inventoryPanel.SetActive(true);
    }

    //open horse panel
    public void OnHorseBTClick()
    {
        horsePanel.SetActive(true);
    }
    
    //open settings panel
    public void OnSettingsBTClick()
    {
        settingsPanel.SetActive(true);
    }

    public void OnFirstBTClick()
    {
        if (isCellOccupied[0])
        {
            SwitchItemType(equippedItemType[0]);
        }
    }

    public void OnSecondBTClick()
    {
        if (isCellOccupied[1])
        {
            SwitchItemType(equippedItemType[1]);
        }
    }

    private void SwitchItemType(string type)
    {
        switch (type)
        {
            case "Pickaxe":
                player.TakePickaxe();
                break;
            case "Axe":
                player.TakeAxe();
                break;
            default:
                break;
        }
    }
}
