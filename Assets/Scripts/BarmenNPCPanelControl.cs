using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmenNPCPanelControl : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private InventoryControl inventory;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject sellLootText;
    private int breadRollPrice = 10;
    private int steakPrice = 50;
    private int friedChickenPrice = 100;
    private float cooldown = 0.5f;
    private bool isInTrigger = false;
    private bool isOnCooldown = false;

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
            //sellLootText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            interactText.SetActive(false);
            //sellLootText.SetActive(false);
        }
    }

    //close shop panel
    public void OnCloseBTClick()
    {
        shopPanel.SetActive(false);
    }

    public void OnFirstBTClick()
    {
        if (saveManager.money >= breadRollPrice && !isOnCooldown)
        {
            StartCoroutine(BuyingCooldown(cooldown));
            inventory.AddItem("Bread Roll");
            saveManager.PayMoney(breadRollPrice);
        }
    }

    public void OnSecondBTClick()
    {
        if (saveManager.money >= steakPrice && !isOnCooldown)
        {
            StartCoroutine(BuyingCooldown(cooldown));
            inventory.AddItem("Steak");
            saveManager.PayMoney(steakPrice);
        }
    }

    public void OnThirdBTClick()
    {
        if (saveManager.money >= friedChickenPrice && !isOnCooldown)
        {
            StartCoroutine(BuyingCooldown(cooldown));
            inventory.AddItem("Fried Chicken");
            saveManager.PayMoney(friedChickenPrice);
        }
    }

    private IEnumerator BuyingCooldown(float time)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(time);
        isOnCooldown = false;
    }
}