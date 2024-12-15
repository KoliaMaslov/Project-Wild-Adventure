using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BuyerNPCScript : MonoBehaviour
{
    [SerializeField] private InventoryControl inventory;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject sellLootText;
    public TextMeshProUGUI moneyText;
    public int money;
    private bool isInTrigger = false;
    void Start()
    {
        money = 1000;
        moneyText.text = "Money: " + money.ToString();
    }


    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                /*Debug.Log("Sell Loot");
                for (int i = 0; i < inventory.lootPositionInArray.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Debug.Log(inventory.lootPositionInArray[j]);
                    }
//                    inventory.DeleteItemInInventory(inventory.lootPositionInArray[i]);
                }*/
                for (int i = 0; i < inventory.itemsType.Length; i++)
                {
                    switch(inventory.itemsType[i])
                    {
                        case "Coal":
                            inventory.DeleteItemInInventory(i);
                            money += 20;
                            break;
                        case "Copper":
                            inventory.DeleteItemInInventory(i);
                            money += 40;
                            break;
                        case "Iron":
                            inventory.DeleteItemInInventory(i);
                            money += 80;
                            break;
                        case "Sandstone":
                            inventory.DeleteItemInInventory(i);
                            money += 60;
                            break;
                        case "Silver":
                            inventory.DeleteItemInInventory(i);
                            money += 120;
                            break;
                        case "Gold":
                            inventory.DeleteItemInInventory(i);
                            money += 200;
                            break;
                        default:
                            break;
                    }
                }
                moneyText.text = "Money: " + money.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            interactText.SetActive(true);
            sellLootText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            interactText.SetActive(false);
            sellLootText.SetActive(false);
        }
    }
}
