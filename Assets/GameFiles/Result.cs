using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int game;
    public Animation Balloon;

    public void Show()
    {
        scoreText.text = ScoreAll.Score.ToString();
        this.gameObject.SetActive(true);
        Balloon.Play();


        switch(game)
        {
            case 6:
                GameSaveManager.ActiveSave.game3Score = ScoreAll.Score;
                break;
        }

        GameSaveManager.SaveToDevice(GameSaveManager.ActiveSave);
    }
    
}
