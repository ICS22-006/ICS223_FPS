using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private OptionsPopup optionsPopup;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Open()
    {
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
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
