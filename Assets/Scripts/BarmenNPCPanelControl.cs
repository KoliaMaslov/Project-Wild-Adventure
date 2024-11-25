using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmenNPCPanelControl : MonoBehaviour
{
    public GameObject shopPanel;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject sellLootText;
    private bool isInTrigger = false;
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
}