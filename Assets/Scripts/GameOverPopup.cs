using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : BasePopup
{
    [SerializeField] private UIController ui;
    private void OnPlayerDead()
    {
        ui.ShowGameOverPopup();
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
    }

    public void OnExitGameButton()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void OnStartAgainButton()
    {
        Close();
        Messenger.Broadcast(GameEvent.RESTART_GAME);
    }
}
