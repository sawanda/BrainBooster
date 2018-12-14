using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    const string namingScene = "Naming";
    public void PushButton()
    {
        SceneManager.LoadScene(namingScene);
    }
}
