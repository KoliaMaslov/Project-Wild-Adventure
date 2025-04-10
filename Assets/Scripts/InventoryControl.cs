using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryControl : MonoBehaviour
{
    [Header("InventorySprites")]
    public GameObject inventoryPanel;
    private Sprite currentItem;
    private string currentType;
    private int chosenItem;

    [Header("ItemsSprites")]
    public Sprite pickaxe;
    public Sprite axe;
    public Sprite gun;
    public Sprite coal;
    public Sprite copper;
    public Sprite iron;
    public Sprite sandstone;
    public Sprite silver;
    public Sprite gold;
    public Sprite rawSteak;
    public Sprite steak;
    public Sprite rawHam;
    public Sprite breadRoll;
    public Sprite friedChicken;
    public Sprite empty;

    [Header("ChosenItem")]
    [SerializeField] private Image chosenItemSprite;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI sellPrice;
    [SerializeField] private GameObject equipBT;
    [SerializeField] private GameObject unequipBT;
    [SerializeField] private GameObject consumeBT;
    [SerializeField] private GameObject buttonBackground;

    [Header("BasicPanel")]
    [SerializeField] private BasicPanelControl basicPanel;

    [Header("InventoryItems")]
    [SerializeField] private TextMeshProUGUI itemsCount;
    [SerializeField] private Image[] images;
    public string[] itemsType = new string[30];
    public bool[] isOccupied = new bool[30];
    private bool[] canBeEquipped = new bool[30];
    private bool[] isItemEquipped = new bool[30];

    private int breadRollHungerRestoration = 10;
    private int steakHungerRestoration = 20;
    private int friedChickenHungerRestoration = 33;

    void Start()
    {
        
    }

    private void Update()
    {
        ItemActionBTState();
        UpdateItemsCount();
    }

    public void InitializeInventory()
    {
        for (int c = 0; c < isOccupied.Length; c++) isOccupied[c] = false;
        for (int c = 0; c < canBeEquipped.Length; c++) canBeEquipped[c] = false;
        for (int c = 0; c < isItemEquipped.Length; c++) isItemEquipped[c] = false;
        for (int c = 0; c < itemsType.Length; c++) itemsType[c] = "Undetected";
    }
    private void UpdateItemsCount()
    {
        int count = 0;
        for (int i = 0; i < isOccupied.Length; i++)
        {
            if (isOccupied[i])
            {
                count++;
            }
        }
        itemsCount.text = count + " / 30";
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
                currentType = "Coal";
                break;
            case "Copper":
                currentItem = copper;
                currentType = "Copper";
                break;
            case "Iron":
                currentItem = iron;
                currentType = "Iron";
                break;
            case "Sandstone":
                currentItem = sandstone;
                currentType = "Sandstone";
                break;
            case "Silver":
                currentItem = silver;
                currentType = "Silver";
                break;
            case "Gold":
                currentItem = gold;
                currentType = "Gold";
                break;
            case "Pickaxe":
                currentItem = pickaxe;
                currentType = "Pickaxe";
                break;
            case "Axe":
                currentItem = axe;
                currentType = "Axe";
                break;
            case "Gun":
                currentItem = gun;
                currentType = "Gun";
                break;
            case "Raw Steak":
                currentItem = rawSteak;
                currentType = "RawSteak";
                break;
            case "Steak":
                currentItem = steak;
                currentType = "Steak";
                break;
            case "Raw Ham":
                currentItem = rawHam;
                currentType = "RawHam";
                break;
            case "Bread Roll":
                currentItem = breadRoll;
                currentType = "BreadRoll";
                break;
            case "Fried Chicken":
                currentItem = friedChicken;
                currentType = "FriedChicken";
                break;
            default:
                currentItem = empty;
                currentType = "Undetected";
                break;
        }
        int i = 0;
        while (isOccupied[i] && i < isOccupied.Length) i++;
        images[i].sprite = currentItem;
        itemsType[i] = currentType;
        if (itemsType[i] != "Undetected")
        {
            isOccupied[i] = true;
        }
    }

    public void DeleteItemInInventory(int pos)
    {
        images[pos].sprite = empty;
        itemsType[pos] = "Undetected";
        isOccupied[pos] = false;
        SetChosenItemToNone();
    }

    public void FirstButton()
    {
        chosenItem = 0;
        SelectItem(chosenItem);
    }
    public void SecondButton()
    {
        chosenItem = 1;
        SelectItem(chosenItem);
    }
    public void ThirdButton()
    {
        chosenItem = 2;
        SelectItem(chosenItem);
    }
    public void FourthButton()
    {
        chosenItem = 3;
        SelectItem(chosenItem);
    }
    public void FifthButton()
    {
        chosenItem = 4;
        SelectItem(chosenItem);
    }
    public void SixthButton()
    {
        chosenItem = 5;
        SelectItem(chosenItem);
    }
    public void SeventhButton()
    {
        chosenItem = 6;
        SelectItem(chosenItem);
    }
    public void EighthButton()
    {
        chosenItem = 7;
        SelectItem(chosenItem);
    }
    public void NinthButton()
    {
        chosenItem = 8;
        SelectItem(chosenItem); 
    }
    public void TenthButton()
    {
        chosenItem = 9;
        SelectItem(chosenItem);
    }
    public void EleventhButton()
    {
        chosenItem = 10;
        SelectItem(chosenItem);
    }
    public void TwelvethButton()
    {
        chosenItem = 11;
        SelectItem(chosenItem);
    }
    public void ThirteenthButton()
    {
        chosenItem = 12;
        SelectItem(chosenItem);
    }
    public void FourteenthButton()
    {
        chosenItem = 13;
        SelectItem(chosenItem);
    }
    public void FifteenthButton()
    {
        chosenItem = 14;
        SelectItem(chosenItem);
    }
    public void SixtheenthButton()
    {
        chosenItem = 15;
        SelectItem(chosenItem);
    }
    public void SeventeenthButton()
    {
        chosenItem = 16;
        SelectItem(chosenItem);
    }
    public void EighteenthButton()
    {
        chosenItem = 17;
        SelectItem(chosenItem);
    }
    public void NineteenthButton()
    {
        chosenItem = 18;
        SelectItem(chosenItem);
    }
    public void TwentythButton()
    {
        chosenItem = 19;
        SelectItem(chosenItem);
    }
    public void TwentyFirstButton()
    {
        chosenItem = 20;
        SelectItem(chosenItem);
    }
    public void TwentySecondButton()
    {
        chosenItem = 21;
        SelectItem(chosenItem);
    }
    public void TwentyThirdButton()
    {
        chosenItem = 22;
        SelectItem(chosenItem);
    }
    public void TwentyFourthButton()
    {
        chosenItem = 23;
        SelectItem(chosenItem);
    }
    public void TwentyFifthButton()
    {
        chosenItem = 24;
        SelectItem(chosenItem);
    }
    public void TwentySixthButton()
    {
        chosenItem = 25;
        SelectItem(chosenItem);
    }
    public void TwentySeventhButton()
    {
        chosenItem = 26;
        SelectItem(chosenItem);
    }
    public void TwentyEighthButton()
    {
        chosenItem = 27;
        SelectItem(chosenItem);
    }
    public void TwentyNinthButton()
    {
        chosenItem = 28;
        SelectItem(chosenItem);
    }
    public void ThirtiethButton()
    {
        chosenItem = 29;
        SelectItem(chosenItem);
    }

    private void SelectItem(int item)
    {
        if (isOccupied[item])
        {
            switch(itemsType[item])
            {
                case "Coal":
                    chosenItemSprite.sprite = coal;
                    itemName.text = "Coal Ore";
                    itemType.text = "Loot";
                    sellPrice.text = "Sell price: 20";
                    break;
                case "Copper":
                    chosenItemSprite.sprite = copper;
                    itemName.text = "Copper Ore";
                    itemType.text = "Loot";
                    sellPrice.text = "Sell price: 40";
                    break;
                case "Sandstone":
                    chosenItemSprite.sprite = sandstone;
                    itemName.text = "Sandstone";
                    itemType.text = "Loot";
                    sellPrice.text = "Sell price: 60";
                    break;
                case "Iron":
                    chosenItemSprite.sprite = iron;
                    itemName.text = "Iron Ore";
                    itemType.text = "Loot";
                    sellPrice.text = "Sell price: 80";
                    break;
                case "Silver":
                    chosenItemSprite.sprite = silver;
                    itemName.text = "Silver Ore";
                    itemType.text = "Loot";
                    sellPrice.text = "Sell price: 120";
                    break;
                case "Gold":
                    chosenItemSprite.sprite = gold;
                    itemName.text = "Gold Ore";
                    itemType.text = "Loot";
                    sellPrice.text = "Sell price: 200";
                    break;
                case "Pickaxe":
                    chosenItemSprite.sprite = pickaxe;
                    itemName.text = "Tier 6 pickaxe";
                    itemType.text = "Tool";
                    sellPrice.text = "Cannot be sold";
                    canBeEquipped[item] = true;
                    break;
                case "Axe":
                    chosenItemSprite.sprite = axe;
                    itemName.text = "Tier 3 axe";
                    itemType.text = "Tool";
                    sellPrice.text = "Cannot be sold";
                    canBeEquipped[item] = true;
                    break;
                case "Gun":
                    chosenItemSprite.sprite = gun;
                    itemName.text = "Vinchester rifle";
                    itemType.text = "Gun";
                    sellPrice.text = "Cannot be sold";
                    canBeEquipped[item] = true;
                    break;
                case "RawSteak":
                    chosenItemSprite.sprite = rawSteak;
                    itemName.text = "Raw Steak";
                    itemType.text = "Loot / Coocking ingredient";
                    sellPrice.text = "Sell Price: 50";
                    break;
                case "Steak":
                    chosenItemSprite.sprite = steak;
                    itemName.text = "Steak";
                    itemType.text = "Food";
                    sellPrice.text = "Restores 20% of hunger";
                    break;
                case "RawHam":
                    chosenItemSprite.sprite = rawHam;
                    itemName.text = "Raw Ham";
                    itemType.text = "Loot / Coocking ingredient";
                    sellPrice.text = "Sell Price: 100";
                    break;
                case "BreadRoll":
                    chosenItemSprite.sprite = breadRoll;
                    itemName.text = "Bread Roll";
                    itemType.text = "Food";
                    sellPrice.text = "Restores 10% of hunger";
                    break;
                case "FriedChicken":
                    chosenItemSprite.sprite = friedChicken;
                    itemName.text = "Fried Chicken";
                    itemType.text = "Food";
                    sellPrice.text = "Restores 33% of hunger";
                    break;
                default:
                    break;
            }
        }
        else if (!isOccupied[item] && itemsType[item] == "Undetected") SetChosenItemToNone();
    }

    private void SetChosenItemToNone()
    {
        chosenItemSprite.sprite = empty;
        itemName.text = null;
        itemType.text = null;
        sellPrice.text = null;
    }

    public void EquipItem()
    {
        if (chosenItemSprite != null && canBeEquipped[chosenItem] && !isItemEquipped[chosenItem])
        {
            int i = 0;
            while (basicPanel.isCellOccupied[i]) i++;
//            canBeEquipped[chosenItem] = false;
            isItemEquipped[chosenItem] = true;
            basicPanel.equippedItems[i].sprite = images[chosenItem].sprite;
            basicPanel.isCellOccupied[i] = true;
            basicPanel.equippedItemType[i] = itemsType[chosenItem];
            equipBT.SetActive(false);
            unequipBT.SetActive(true);
        }
    }

    public void UnequipItem()
    {
        if (chosenItemSprite != null && isItemEquipped[chosenItem])
        {
            int i = 0;
            while (i < basicPanel.equippedItemType.Length && basicPanel.equippedItemType[i] != itemsType[chosenItem]) i++;
            isItemEquipped[chosenItem] = false;
            basicPanel.equippedItems[i].sprite = empty;
            basicPanel.isCellOccupied[i] = false;
            basicPanel.equippedItemType[i] = "Undetected";
            unequipBT.SetActive(false);
            equipBT.SetActive(true);
        }
    }

    private void ItemActionBTState()
    {
        if (!isItemEquipped[chosenItem] && canBeEquipped[chosenItem])
        {
            buttonBackground.SetActive(true);
            unequipBT.SetActive(false);
            equipBT.SetActive(true);
            consumeBT.SetActive(false);
        }
        else if (isItemEquipped[chosenItem] && canBeEquipped[chosenItem])
        {
            buttonBackground.SetActive(true);
            equipBT.SetActive(false);
            unequipBT.SetActive(true);
            consumeBT.SetActive(false);
        }
        else if (itemsType[chosenItem] == "BreadRoll" || itemsType[chosenItem] == "Steak" || itemsType[chosenItem] == "FriedChicken")
        {
            buttonBackground.SetActive(true);
            equipBT.SetActive(false);
            unequipBT.SetActive(false);
            consumeBT.SetActive(true);
        }
        else
        {
            buttonBackground.SetActive(false);
            equipBT.SetActive(false);
            unequipBT.SetActive(false);
            consumeBT.SetActive(false);
        }
    }

    private void RestoreHunger(int ammount)
    {
        basicPanel.hunger += ammount;
        basicPanel.HungerTextUpdate(basicPanel.hunger);
    }

    public void ConsumeItem()
    {
        switch (itemsType[chosenItem])
        {
            case "BreadRoll":
                if (basicPanel.hunger <= 100 - breadRollHungerRestoration)
                {
                    RestoreHunger(breadRollHungerRestoration);
                    DeleteItemInInventory(chosenItem);
                }
                break;
            case "Steak":
                if (basicPanel.hunger <= 100 - steakHungerRestoration)
                {
                    RestoreHunger(steakHungerRestoration);
                    DeleteItemInInventory(chosenItem);
                }
                break;
            case "FriedChicken":
                if (basicPanel.hunger <= 100 - friedChickenHungerRestoration)
                {
                    RestoreHunger(friedChickenHungerRestoration);
                    DeleteItemInInventory(chosenItem);
                }
                break;
            default:
                break;
        }
    }
}
