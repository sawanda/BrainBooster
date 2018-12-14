using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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

    const string keyNames = "names";
    const string keyActiveName = "activeName";

    private bool CheckDuplicateName(string name)
    {
        string allNames = PlayerPrefs.GetString(keyNames, "");
        string[] allNamesArray = allNames.Split(',');
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
        string allNames = PlayerPrefs.GetString(keyNames, "");
        allNames = allNames + "," + newName;
        PlayerPrefs.SetString(keyNames, allNames);
    }

    private void SetNameAsActive(string nameToActive) => PlayerPrefs.SetString(keyActiveName, nameToActive);
}
