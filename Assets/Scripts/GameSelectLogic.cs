using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectLogic : MonoBehaviour
{
    public const string learnSceneName = "Learn";
    public const string playSceneName = "Play";
    public const string statsSceneName = "Stats";
   public const string Game5SceneName = "Game5";
   public const string Game6SceneName = "Game6"; 
   public const string Game7SceneName = "Game7";
   public const string GameSelectName = "GameSelect"; 
    public void BackToTitleScreen() => SceneManager.LoadScene(TitleScreen.titleSceneName);
    public void BackToGameSelectScreen() => SceneManager.LoadScene(GameSelectName);
    public void GoToLearn() => SceneManager.LoadScene(learnSceneName);
    public void GoToPlay() => SceneManager.LoadScene(playSceneName);

    public void GoToStats() => SceneManager.LoadScene(statsSceneName);
    public void GoToGame5() => SceneManager.LoadScene(Game5SceneName);
    public void GoToGame6() => SceneManager.LoadScene(Game6SceneName);
    public void GoToGame7() => SceneManager.LoadScene(Game7SceneName);
}
