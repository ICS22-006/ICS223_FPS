using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    [SerializeField] private UIController uiController;
    [SerializeField] private SettingsPopup settingsPopup;

    override public void Open()
    {
        base.Open();
    }
    override public void Close()
    {
        base.Close();
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnSettingsButton()
    {
        Close();
        settingsPopup.Open();
        Debug.Log("settings clicked");
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
        uiController.SetGameActive(true);
    }

}
