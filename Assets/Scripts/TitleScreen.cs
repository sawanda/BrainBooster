using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public const string titleSceneName = "Title";
    public const string gameSelectSceneName = "GameSelect";

    public void PushButton()
    {
        if (PlayerPrefs.GetString(PlayerPrefManager.keyActiveName, "") == "")
        {
            NamingLogic.GoToNaming(nextScene: gameSelectSceneName, backScene: titleSceneName);
        }
        else
        {
            SceneManager.LoadScene(gameSelectSceneName);
        }
    }
}
