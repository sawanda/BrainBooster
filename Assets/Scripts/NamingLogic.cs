using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NamingLogic : MonoBehaviour
{
    [SerializeField] private TMP_InputField namingBox;

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
        SetNameAsActive(namingBox.text);

        SceneManager.LoadScene(nextSceneRemember);
    }

    private bool CheckDuplicateName(string name)
    {
        string[] allNamesArray = PlayerPrefManager.AllPlayerNames();
        if (allNamesArray.Contains(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [MenuItem("BrainBooster/Reset Everything")]
    public static void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    private void RegisterName(string newName)
    {
        string[] allNames = PlayerPrefManager.AllPlayerNames();
        // [AAA BBB CCC]
        if (allNames.Length == 1 && allNames[0] == "") 
        {
            PlayerPrefs.SetString(PlayerPrefManager.keyNames, newName);
        }
        else
        {
            var allNamesAddedNewName = allNames.Concat(new string[] { newName });
            string prepareToSaveBack = string.Join(",", allNamesAddedNewName);
            //"AAA,BBB,CCC,DDD"
            PlayerPrefs.SetString(PlayerPrefManager.keyNames, prepareToSaveBack);
        }
    }

    private void SetNameAsActive(string nameToActive) 
        => PlayerPrefs.SetString(PlayerPrefManager.keyActiveName, nameToActive);
}
