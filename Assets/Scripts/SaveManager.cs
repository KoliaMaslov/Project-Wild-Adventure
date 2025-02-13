using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private BasicPanelControl basicPanel;

    public int money;
    private int basicMoney = 1000;

    void Start()
    {
        LoadMoney();
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
}
