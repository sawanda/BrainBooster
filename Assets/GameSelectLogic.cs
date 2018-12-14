using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectLogic : MonoBehaviour
{
    public void BackToTitleScreen() => SceneManager.LoadScene(TitleScreen.titleSceneName);
}
