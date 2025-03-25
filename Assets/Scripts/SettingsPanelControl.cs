using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelControl : MonoBehaviour
{
    [SerializeField] private BasicPanelControl basicPanel;
    [SerializeField] private TextMeshProUGUI firstCheckText;
    [SerializeField] private GameObject settingsPanel;
    private bool canPlayMusic = true;
    void Start()
    {
        
    }

    //close settings panel
    public void OnCloseBTClick()
    {
        settingsPanel.SetActive(false);
    }

    public void OnFirstCheckBTClick()
    {
        SwitchParameterState();
        SwitchBTState(canPlayMusic, firstCheckText);
        ChangeGameMusicState();
    }

    private void SwitchParameterState()
    {
        if (canPlayMusic) canPlayMusic = false;
        else if (!canPlayMusic) canPlayMusic = true;
    }

    private void SwitchBTState(bool state, TextMeshProUGUI buttonText)
    {
        if (state) buttonText.text = "X";
        if (!state) buttonText.text = null;
    }

    private void ChangeGameMusicState()
    {
        if (canPlayMusic) basicPanel.PlayMusic();
        if (!canPlayMusic) basicPanel.StopMusic();
    }
}
