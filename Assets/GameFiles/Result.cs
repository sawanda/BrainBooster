using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int game;

    public void Show()
    {
        scoreText.text = Utility.correctCount.ToString();
        this.gameObject.SetActive(true);


        switch(game)
        {
            case 6:
                GameSaveManager.ActiveSave.game3Score = Utility.correctCount;
                break;
        }

        GameSaveManager.SaveToDevice(GameSaveManager.ActiveSave);
    }
    
}
