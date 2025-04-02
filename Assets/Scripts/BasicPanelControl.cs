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
    public GameObject confirmActionsPanel;
    public int health;
    public int stamina;
    public int hunger;
    [SerializeField] private TextMeshProUGUI healthBar;
    [SerializeField] private TextMeshProUGUI staminaBar;
    [SerializeField] private TextMeshProUGUI hungerBar;
    [SerializeField] private GameObject aimImage;
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Other Scripts")]
    [SerializeField] private SpawnMenu _spawnScript;
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private PlayerMainScript _mainPlayer;
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameMusicClip;
    [SerializeField] private GameObject playerObj;
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
        audioSource.clip = gameMusicClip;
        PlayMusic();
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
        if (Input.GetKeyDown(KeyCode.Alpha3) && isCellOccupied[2])
        {
            SwitchItemType(equippedItemType[2]);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) confirmActionsPanel.SetActive(true);
        if (!isMoneyAchievementComplete && _saveManager.money >= 2000)
        {
            isMoneyAchievementComplete = true;
            achievementBT.SetActive(true);
        }
        if (health <= 0)
        {
            _mainPlayer.MakeHandsFree();
            _mainPlayer.UnlockCursor();
            gameEndBadScenarionPanel.SetActive(true);
            _spawnScript.isSpawned = false;
            Destroy(playerObj);
        }
        if (_mainPlayer.isGunEquipped) aimImage.SetActive(true);
        else if (!_mainPlayer.isGunEquipped) aimImage.SetActive(false);
    }

    public void InitializeMainPlayerScript(PlayerMainScript mainPlayer)
    {
        if (_mainPlayer == null)
        {
            _mainPlayer = mainPlayer;
        }
    }
    public void InitializePlayerMovementScript(PlayerMovement playerMovement)
    {
        if (_playerMovement == null)
        {
            _playerMovement = playerMovement;
        }
    }

    public void InitializePlayerObj(GameObject player)
    {
        if (playerObj == null)
        {
            playerObj = player;
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
                _mainPlayer.TakePickaxe();
                break;
            case "Axe":
                _mainPlayer.TakeAxe();
                break;
            case "Gun":
                _mainPlayer.TakeGun();
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

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
