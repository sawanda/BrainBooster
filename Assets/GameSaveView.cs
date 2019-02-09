using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveView : MonoBehaviour
{
    public Image animalImage;
    public TextMeshProUGUI playerName;

    public Sprite[] animalSprites;

    public bool startWithActiveSave;

    public void Start()
    {
        if (startWithActiveSave)
        {
            DisplayGameSave(GameSaveManager.ActiveSave);
        }
    }

    public void Hide()
    {
        // playerName.text = "";
        // animalImage.sprite = null;
        this.gameObject.SetActive(false);
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
