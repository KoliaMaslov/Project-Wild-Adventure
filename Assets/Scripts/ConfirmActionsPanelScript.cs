using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmActionsPanelScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void OnConfirmBTClick()
    {
        panel.SetActive(false);
        Application.Quit();
    }

    public void OnCancelBTClick()
    {
        panel.SetActive(false);
    }
}
