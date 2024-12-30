using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryPanel;
    private Sprite currentItem;
    private string currentType;
    private int chosenItem;
    

    [Header("ItemsSprites")]
    public Sprite pickaxe;
    public Sprite axe;
    public Sprite coal;
    public Sprite copper;
    public Sprite iron;
    public Sprite sandstone;
    public Sprite silver;
    public Sprite gold;
    public Sprite empty;

    [Header("ChosenItem")]
    [SerializeField] private Image chosenItemSprite;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI sellPrice;
    [SerializeField] private GameObject equipBT;
    [SerializeField] private GameObject unequipBT;

    [Header("BasicPanel")]
    [SerializeField] private BasicPanelControl basicPanel;

    [Header("InventorySprites")]
    [SerializeField] private TextMeshProUGUI itemsCount;
    [SerializeField] private Image[] images;
    public string[] itemsType = new string[30];
    private bool[] isOccupied = new bool[30];
    private bool[] canBeEquipped = new bool[30];
    private bool[] isItemEquipped = new bool[30];

    void Start()
    {
        for (int c = 0; c < isOccupied.Length; c++) isOccupied[c] = false;
        for (int c = 0; c < canBeEquipped.Length; c++) canBeEquipped[c] = false;
        for (int c = 0; c < isItemEquipped.Length; c++) isItemEquipped[c] = false;
        for (int c = 0; c < itemsType.Length; c++) itemsType[c] = "Undetected";
        AddItem("Pickaxe");
        AddItem("Axe");
    }

    private void Update()
    {
        EquipItemBTState();
        UpdateItemsCount();
    }

    private void UpdateItemsCount()
    {
        int count = 0;
        for (int i = 0; i < isOccupied.Length; i++)
        {
            if (isOccupied[i]) count++;
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
        }
        int i = 0;
        while (isOccupied[i] && i < isOccupied.Length) i++;
        images[i].sprite = currentItem;
        itemsType[i] = currentType;
        isOccupied[i] = true;
    }

    public void DeleteItemInInventory(int pos)
    {
        images[pos].sprite = empty;
        itemsType[pos] = "Undetected";
        isOccupied[pos] = false;
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
                    canBeEquipped[item] = true;
                    break;
                case "Axe":
                    chosenItemSprite.sprite = axe;
                    itemName.text = "Tier 3 axe";
                    itemType.text = "Tool";
                    canBeEquipped[item] = true;
                    break;
                default:
                    break;
            }
        }
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

    private void EquipItemBTState()
    {
        if (chosenItemSprite != null && !isItemEquipped[chosenItem])
        {
            unequipBT.SetActive(false);
            equipBT.SetActive(true);
        }
        else if (chosenItemSprite != null && isItemEquipped[chosenItem])
        {
            equipBT.SetActive(false);
            unequipBT.SetActive(true);
        }
        else
        {
            equipBT.SetActive(false);
            unequipBT.SetActive(false);
        }
    }
}
