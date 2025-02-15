using UnityEngine;

public class MiningNPCControl : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private InventoryControl inventory;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject sellLootText;
    [SerializeField] private GameObject firstButton;
    [SerializeField] private GameObject secondButton;
    [SerializeField] private GameObject thirdButton;
    [SerializeField] private GameObject fourthButton;
    [SerializeField] private GameObject fifthButton;
    private bool isInTrigger = false;
    private string firstItemType = "Pickaxe";
    void Start()
    {
        
    }


    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                shopPanel.SetActive(true);
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

    //close shop panel
    public void OnCloseBTClick()
    {
        shopPanel.SetActive(false);
    }

    //buy first item
    public void OnFirstBTClick()
    {
        if (saveManager.money >= 500)
        {
            firstButton.SetActive(false);
            inventory.AddItem(firstItemType);
            saveManager.PayMoney(500);
            saveManager.SavePickaxe(firstItemType);
        }
    }
}
