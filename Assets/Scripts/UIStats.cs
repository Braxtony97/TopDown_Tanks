using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    [SerializeField] private Text _hpText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _scoreText;

    public void UpdateScoreAndLevel()
    {
        _levelText.text = $"Level: {Stats.Level}";
        _scoreText.text = "Score: " + Stats.Score.ToString("D4"); // score = 23 -> 0023 (4 знака)
    }

    public void UpdateHp(int health)
    {
        _hpText.text = $"HP: {health}";
    }
}
