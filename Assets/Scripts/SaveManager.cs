using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private BasicPanelControl basicPanel;
    [SerializeField] private InventoryControl inventory;

    public int money;
    private int basicMoney = 1000;

    void Start()
    {
        inventory.InitializeInventory();
        LoadMoney();
        LoadPickaxe();
        LoadGun();
    }

    private void LoadMoney()
    {
        money = PlayerPrefs.GetInt("Money", basicMoney);
        basicPanel.MoneyTextUpdate(money);
    }

    public void AddMoney(int ammount)
    {
        money += ammount;
        PlayerPrefs.SetInt("Money", money);
        basicPanel.MoneyTextUpdate(money);
    }

    public void PayMoney(int ammount)
    {
        money -= ammount;
        PlayerPrefs.SetInt("Money", money);
        basicPanel.MoneyTextUpdate(money);
    }

    public void SaveGun(string itemType)
    {
        PlayerPrefs.SetString("Gun", itemType);
    }

    public void SavePickaxe(string itemType)
    {
        PlayerPrefs.SetString("Pickaxe", itemType);
    }

    public void LoadGun()
    {
        inventory.AddItem(PlayerPrefs.GetString("Gun", "Undetected"));
    }

    public void LoadPickaxe()
    {
        inventory.AddItem(PlayerPrefs.GetString("Pickaxe", "Undetected"));
    }
}
