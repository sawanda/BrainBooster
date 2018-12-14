using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectLogic : MonoBehaviour
{
    const string learnSceneName = "Learn";
    const string playSceneName = "Play";
    
    public void BackToTitleScreen() => SceneManager.LoadScene(TitleScreen.titleSceneName);
    public void GoToLearn() => SceneManager.LoadScene(learnSceneName);
    public void GoToPlay() => SceneManager.LoadScene(playSceneName);
}
