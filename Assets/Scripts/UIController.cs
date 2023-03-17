using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    private int popupsActive = 0;

    // private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
        SetGameActive(true);
        // UpdateScore(score);
        UpdateHealth(1f);
    }

    private void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }
    private void OnPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0)
        {
            SetGameActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (popupsActive == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && !settingsPopup.IsActive())
            {
                optionsPopup.Open();
            }
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        print("SetGameActive: " + active);
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor 
            crossHair.gameObject.SetActive(true); // show the crosshair
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
        }
    }

    public void UpdateHealth(float healthPercentage)
    {
        OnHealthChanged(healthPercentage);
    }

    public void OnHealthChanged(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthBar.fillAmount);
    }
}
