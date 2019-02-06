using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrainCollider : MonoBehaviour
{
    const string Game1 = nameof(Game1);
    const string Game2 = nameof(Game2);
    const string Game3 = nameof(Game3);
    const string Game4 = nameof(Game4);

    public void StartGame1()
    {
        SceneManager.LoadScene(Game1);
    }

    public void StartGame2()
    {
        SceneManager.LoadScene(Game2);
    }

    public void StartGame3()
    {
        SceneManager.LoadScene(Game3);
    }

    public void StartGame4()
    {
        SceneManager.LoadScene(Game4);
    }

}
