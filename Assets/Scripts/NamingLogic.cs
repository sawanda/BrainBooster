using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class NamingLogic : MonoBehaviour
{

#if UNITY_EDITOR
    [MenuItem("BrainBooster/Reset Everything")]
    public static void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
#endif

    public TMP_InputField namingBox;
    public Toggle toggleBoy;
    public Toggle toggleGirl;
    public TMP_InputField age;
    public GameObject warning;
   
    

    const string namingScene = "Naming";

    private static string nextSceneRemember;
    private static string backSceneRemember;
    public static void GoToNaming(string nextScene, string backScene)
    {
        nextSceneRemember = nextScene;
        backSceneRemember = backScene;
        SceneManager.LoadScene(namingScene);
    }

    public void BackPress() => SceneManager.LoadScene(backSceneRemember);
    public void NextPress()
    {
        if(namingBox.text == "") return;
        int ageInteger = int.Parse(age.text);
        if(ageInteger < 2 || ageInteger > 5) return;
        if(toggleBoy.isOn == false && toggleGirl.isOn == false) return;
        if (CheckDuplicateName(namingBox.text) == true)
        {
            warning.SetActive(true);
            return;
        }
        string gender = toggleBoy.isOn ? "boy" : "girl";
        print("Register");
        UserService.register(namingBox.text,age.text,gender,"1234");
        RegisterNewPlayer(namingBox.text, ageInteger, toggleBoy.isOn ? GameSave.Sex.Boy : GameSave.Sex.Girl);
        GameSaveManager.SetNameAsActive(namingBox.text);
        

        PlayerPrefs.SetInt("role", 0);
        // PlayerPrefs.DeleteKey("role");


        SceneManager.LoadScene(nextSceneRemember);
    }


    private bool CheckDuplicateName(string name)
    {
        string[] allNamesArray = GameSaveManager.AllPlayerNames;
        if (allNamesArray.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void RegisterNewPlayer(string newName, int age, GameSave.Sex sex)
    {
        GameSave newPlayer = new GameSave(newName, age, sex);
        GameSaveManager.SaveToDevice(newPlayer);
    }

}
