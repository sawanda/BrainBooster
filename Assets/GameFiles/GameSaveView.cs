using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveView : MonoBehaviour
{
    public Image animalImage;
    public Image border;
    public TextMeshProUGUI playerName;

    public Sprite[] animalSprites;

    public bool alwaysDisplayActiveSave;

    public void Hide()
    {
        // playerName.text = "";
        // animalImage.sprite = null;
        this.gameObject.SetActive(false);
    }

    public void Update()
    {
        UpdateBorder();
        if (alwaysDisplayActiveSave)
        {
            DisplayGameSave(GameSaveManager.ActiveSave);
        }
    }

    public void Selected()
    {
        GameSaveManager.SetNameAsActive(playerName.text);
    }

    private void UpdateBorder()
    {
        if(border == null) return;
        if(GameSaveManager.ActiveSave.name == playerName.text)
        {
            Color c = border.color;
            c.a = 1;
            border.color = c;
        }
        else
        {
            Color c = border.color;
            c.a = 0;
            border.color = c;
        }
    }

    public void DisplayGameSave(GameSave gameSave)
    {
        if (gameSave == null)
        {
            Hide();
        }
        else
        {
            this.gameObject.SetActive(true);
            switch (gameSave.iconType)
            {
                case IconType.Bear: animalImage.sprite = animalSprites[0]; break;
                case IconType.Panda: animalImage.sprite = animalSprites[1]; break;
                case IconType.Rabbit: animalImage.sprite = animalSprites[2]; break;
            }

            playerName.text = gameSave.name;
        }
    }
}
