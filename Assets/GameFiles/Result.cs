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
            case 1:
                GameSaveManager.ActiveSave.game5Score.RecordScore(ScoreAll.Score);
                break;
            case 2:
                GameSaveManager.ActiveSave.game6Score.RecordScore(ScoreAll.Score);
                break;
            case 3:
                GameSaveManager.ActiveSave.game9Score.RecordScore(ScoreAll.Score);
                break;
            case 4:
                GameSaveManager.ActiveSave.game10Score.RecordScore(ScoreAll.Score);
                break;
        }
        Debug.Log(GameSaveManager.ActiveSave.game6Score);

        GameSaveManager.SaveToDevice(GameSaveManager.ActiveSave);
    }
    
}
