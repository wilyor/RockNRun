using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public AccuracyManager accuracyManager;
    public TextMeshProUGUI comboText;
    public int currentScore = 0;
    public int currentCombo = 0;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void ReceiveScore(Accuracy accuracy, int score)
    {
        currentScore += score;
        currentCombo = score != 0 ? ++currentCombo : 0;
        ShowAccuracyText(accuracy);
        ShowComboText();
    }

    public void ShowAccuracyText(Accuracy accuracy = Accuracy.Miss)
    {
        if (accuracyManager)
        {
            accuracyManager.gameObject.SetActive(false);
            accuracyManager.gameObject.SetActive(true);
            accuracyManager.SetText(accuracy);
        }
    }

    public void ShowComboText()
    {
        comboText.gameObject.SetActive(false);
        if (currentCombo < 2) return;
        comboText.gameObject.SetActive(true);
        comboText.text = "Combo\n" + currentCombo;
    }
}
