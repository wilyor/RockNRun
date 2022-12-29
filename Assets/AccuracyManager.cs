using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Accuracy
{
    Miss,
    Great,
    Perfect
}

public class AccuracyManager : MonoBehaviour
{
    public TextMeshProUGUI accuracyText;
    Animator anim;
    public Color missColor;
    public Color PerfectColor;
    public Color GreatColor;


    public void SetText(Accuracy accuracy)
    {
        accuracyText.text = accuracy.ToString();
        accuracyText.color = SelectColor(accuracy);
    }

    private void OnEnable()
    {
        if (!anim) anim = GetComponent<Animator>();
        anim.SetTrigger("Appear");
    }

    public void Dissapear()
    {
        gameObject.SetActive(false);
    }

    Color SelectColor(Accuracy accuracy)
    {
        switch (accuracy)
        {
            case Accuracy.Great:
                return GreatColor;
            case Accuracy.Perfect:
                return PerfectColor;
            case Accuracy.Miss:
                return missColor;
            default:
                return GreatColor;
        }
    }
}
