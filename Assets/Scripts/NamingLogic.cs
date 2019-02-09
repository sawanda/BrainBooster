using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (CheckDuplicateName(namingBox.text) == true) return;

        RegisterName(namingBox.text);
        GameSaveManager.SetNameAsActive(namingBox.text);

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

    private void RegisterName(string newName)
    {
        GameSave newPlayer = new GameSave(newName);
        GameSaveManager.SaveToDevice(newPlayer);
    }

}
