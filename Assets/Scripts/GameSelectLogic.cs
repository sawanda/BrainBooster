using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelectLogic : MonoBehaviour
{   
     public GameObject fullpack;
     private string name;
     public void Start() {

        // PlayerPrefs.DeleteKey("role");

        name = PlayerPrefs.GetString("ActiveLastTime");


        fullpack.SetActive(false);
        int role = PlayerPrefs.GetInt(name+"_role", 0);
        if(role == 1){
            status = true;
        } else {
            status = false;
        }

     }

    public const string learnSceneName = "Learn";
    public const string playSceneName = "Play";
    public const string statsSceneName = "Stats";
   public const string Game5SceneName = "Game5";
   public const string Game6SceneName = "Game6"; 
   public const string Game7SceneName = "Game7";
   
   public const string Game9SceneName = "Game9";
   
   public const string Game10SceneName = "Game10";
   
   public const string GameSelectName = "GameSelect"; 
    public void BackToTitleScreen() => SceneManager.LoadScene(TitleScreen.titleSceneName);
    public void BackToGameSelectScreen() => SceneManager.LoadScene(GameSelectName);
    public void GoToLearn() => SceneManager.LoadScene(learnSceneName);
    public void GoToPlay() => SceneManager.LoadScene(playSceneName);

    private bool status = false;

    public void GoToStats() {
        if(!fullpack.activeSelf) {
          SceneManager.LoadScene(statsSceneName);
        }
    } 
    public void GoToGame5() {
         if(status){
          SceneManager.LoadScene(Game5SceneName);
         } else {
            fullpack.SetActive(true);
         }

    } 
    public void GoToGame6() {
        if(status){
          SceneManager.LoadScene(Game6SceneName);
         } else {
            fullpack.SetActive(true);
         }
    } 
    public void GoToGame9() { 
        if(!fullpack.activeSelf) {
            if(status){
                 SceneManager.LoadScene(Game6SceneName);
            } else {
                fullpack.SetActive(true);
            }
        } else {
           clickBuyButton();
        }
    }

     public void GoToGame7(){ 
         if(!fullpack.activeSelf) {
            SceneManager.LoadScene(Game7SceneName);
        }
    }
    
    public void GoToGame10() {
         if(!fullpack.activeSelf) {
            SceneManager.LoadScene(Game10SceneName);
        }

    }

     public void clickBuyButton() {
        PlayerPrefs.SetInt(name+"_role", 1);
        fullpack.SetActive(false);
        status = true;
    }

}
