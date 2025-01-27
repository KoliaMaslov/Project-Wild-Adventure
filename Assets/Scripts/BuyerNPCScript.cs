using UnityEngine.UI;
using UnityEngine;

public class BuyerNPCScript : MonoBehaviour
{
    [SerializeField] private BasicPanelControl basicPanel;
    [SerializeField] private InventoryControl inventory;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject sellLootText;
    private bool isInTrigger = false;
    void Start()
    {

    }


    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Sell Loot");
                for (int i = 0; i < inventory.itemsType.Length; i++)
                {
                    switch(inventory.itemsType[i])
                    {
                        case "Coal":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 20;
                            break;
                        case "Copper":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 40;
                            break;
                        case "Iron":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 80;
                            break;
                        case "Sandstone":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 60;
                            break;
                        case "Silver":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 120;
                            break;
                        case "Gold":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 200;
                            break;
                        case "RawSteak":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 50;
                            break;
                        case "RawHam":
                            inventory.DeleteItemInInventory(i);
                            basicPanel.money += 100;
                            break;
                        default:
                            break;
                    }
                }
                basicPanel.moneyText.text = "Money: " + basicPanel.money.ToString();
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
