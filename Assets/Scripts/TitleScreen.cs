using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    const string titleSceneName = "Title";
    const string gameSelectSceneName = "GameSelect";
    public void PushButton()
    {
        NamingLogic.GoToNaming(nextScene: gameSelectSceneName, backScene: titleSceneName);
    }
}
