using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicPanelControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject horsePanel;
    public GameObject settingsPanel;
    public GameObject gameEndPanel;
    public GameObject goalPanel;
    public GameObject achievementBT;

    [SerializeField] private PlayerMainScript player;
    public GameObject temp;

    public TextMeshProUGUI moneyText;
    public int money;
    public int completedAchievements;
    private int achievementsToComplete = 1;
    private bool isMoneyAchievementComplete = false;

    public Image[] equippedItems;
    public bool[] isCellOccupied = new bool[6];
    public string[] equippedItemType = new string[6];
    void Start()
    {
        for (int c = 0; c < isCellOccupied.Length; c++) isCellOccupied[c] = false;
        temp = GameObject.FindGameObjectWithTag("Player");
        temp.TryGetComponent<PlayerMainScript>(out player);

        money = 1000;
        moneyText.text = "Money: " + money.ToString();
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
        if (!isMoneyAchievementComplete && money >= 2000)
        {
            isMoneyAchievementComplete = true;
            achievementBT.SetActive(true);
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

    public void OnAchievementBTClick()
    {
        CompleteAchievement();
        achievementBT.SetActive(false);
    }

    private void CompleteAchievement()
    {
        completedAchievements++;
        achievementBT.SetActive(false);
        StartCoroutine(GotAchievement(5));
    }

    IEnumerator GotAchievement(float seconds)
    {
        goalPanel.SetActive(true);
        yield return new WaitForSeconds(seconds);
        goalPanel.SetActive(false);
        if (completedAchievements == achievementsToComplete)
        {
            gameEndPanel.SetActive(true);
        }
    }
}
