using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private OptionsPopup optionsPopup;

    override public void Open()
    {
        base.Open();
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }
    override public void Close()
    {
        base.Close();
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void OnOKButton()
    {
        Close();
        optionsPopup.Open();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopup.Open();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyValue.text = ((int)difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
}
