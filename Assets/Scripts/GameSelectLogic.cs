using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectLogic : MonoBehaviour
{
    public const string learnSceneName = "Learn";
    public const string playSceneName = "Play";
    public const string statsSceneName = "Stats";
    
    public void BackToTitleScreen() => SceneManager.LoadScene(TitleScreen.titleSceneName);
    public void GoToLearn() => SceneManager.LoadScene(learnSceneName);
    public void GoToPlay() => SceneManager.LoadScene(playSceneName);
    public void GoToStats() => SceneManager.LoadScene(statsSceneName);
}
