using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicPanelControl : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject inventoryPanel;
    public GameObject horsePanel;
    public GameObject settingsPanel;
    public GameObject gameEndPanel;
    public GameObject goalPanel;
    public GameObject achievementBT;
    public GameObject gameEndBadScenarionPanel;
    public int health;
    public int stamina;
    public int hunger;
    [SerializeField] private TextMeshProUGUI healthBar;
    [SerializeField] private TextMeshProUGUI staminaBar;
    [SerializeField] private TextMeshProUGUI hungerBar;
    [SerializeField] private GameObject aimImage;
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Other Scripts")]
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private PlayerMainScript mainPlayer;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private GameObject playerObj;
    public GameObject temp;
    public int completedAchievements;
    private int achievementsToComplete = 1;
    private bool isMoneyAchievementComplete = false;

    public Image[] equippedItems;
    public bool[] isCellOccupied = new bool[6];
    public string[] equippedItemType = new string[6];
    void Start()
    {
        for (int c = 0; c < isCellOccupied.Length; c++) isCellOccupied[c] = false;
        HealthTextUpdate(health);
        StaminaTextUpdate(stamina);
        HungerTextUpdate(hunger);
    }

    void Update()
    {
        if (mainPlayer == null)
        {
            temp = GameObject.FindGameObjectWithTag("Player");
            temp.TryGetComponent<PlayerMainScript>(out mainPlayer);
        }
        if (playerMovement == null)
        {
            temp = GameObject.FindGameObjectWithTag("Player");
            temp.TryGetComponent<PlayerMovement>(out playerMovement);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && isCellOccupied[0])
        {
            SwitchItemType(equippedItemType[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isCellOccupied[1])
        {
            SwitchItemType(equippedItemType[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isCellOccupied[2])
        {
            SwitchItemType(equippedItemType[2]);
        }
        if (!isMoneyAchievementComplete && saveManager.money >= 2000)
        {
            isMoneyAchievementComplete = true;
            achievementBT.SetActive(true);
        }
        if (health <= 0)
        {
            gameEndBadScenarionPanel.SetActive(true);
            Destroy(playerObj);
        }
        if (playerObj == null) playerObj = GameObject.FindGameObjectWithTag("Player");
        if (mainPlayer.isGunEquipped) aimImage.SetActive(true);
        else if (!mainPlayer.isGunEquipped) aimImage.SetActive(false);
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

    public void OnThirdBTClich()
    {
        if (isCellOccupied[2])
        {
            SwitchItemType(equippedItemType[2]);
        }
    }

    private void SwitchItemType(string type)
    {
        switch (type)
        {
            case "Pickaxe":
                mainPlayer.TakePickaxe();
                break;
            case "Axe":
                mainPlayer.TakeAxe();
                break;
            case "Gun":
                mainPlayer.TakeGun();
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

    public void HealthTextUpdate(int number)
    {
        healthBar.text = number.ToString() + "%";
    }

    public void StaminaTextUpdate(int number)
    {
        staminaBar.text = number.ToString() + "%";
    }

    public void HungerTextUpdate(int number)
    {
        hungerBar.text = number.ToString() + "%";
    }

    public void MoneyTextUpdate(int number)
    {
        moneyText.text = "Money: " + number.ToString();
    }
}
