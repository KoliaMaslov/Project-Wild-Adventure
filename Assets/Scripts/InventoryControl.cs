using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    private Sprite currentItem;

    [Header("ItemsSprites")]
    public Sprite pickaxe;
    public Sprite axe;
    public Sprite coal;
    public Sprite copper;
    public Sprite iron;
    public Sprite sandstone;
    public Sprite silver;
    public Sprite gold;

    [Header("InventorySprites")]
    [SerializeField] private Image[] images;
    private bool[] isOccupied = new bool[30];

    void Start()
    {
//        images[0].sprite = pickaxe;
//        images[1].sprite = axe;
        for (int c = 0; c < isOccupied.Length; c++) isOccupied[c] = false;
        AddItem("Pickaxe");
        AddItem("Axe");
    }

    private void Update()
    {
/*        if (Input.GetMouseButtonDown(1))
        {
            images[0].sprite = pickaxe;
        }*/
    }

    //close inventory panel
    public void OnCloseBTClick()
    {
        inventoryPanel.SetActive(false);
    }

    public void AddItem(string item)
    {
        switch (item)
        {
            case "Coal":
                currentItem = coal;
                break;
            case "Copper":
                currentItem = copper;
                break;
            case "Iron":
                currentItem = iron;
                break;
            case "Sandstone":
                currentItem = sandstone;
                break;
            case "Silver":
                currentItem = silver;
                break;
            case "Gold":
                currentItem = gold;
                break;
            case "Pickaxe":
                currentItem = pickaxe;
                break;
            case "Axe":
                currentItem = axe;
                break;
        }
        int i = 0;
        while (isOccupied[i] && i < isOccupied.Length) i++;
        images[i].sprite = currentItem;
        isOccupied[i] = true;
    }
}
