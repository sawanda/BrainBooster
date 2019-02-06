using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    private void BackToTrain() => SceneManager.LoadScene(GameSelectLogic.learnSceneName);

    public Button forwardButton;
    public RectTransform[] pages;
    public int currentPage = 0;

    public void Start()
    {
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void Forward()
    {
        currentPage++;
        currentPage = Mathf.Clamp(currentPage, 0, pages.Length);
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void Backward()
    {
        currentPage--;
        if (currentPage == -1)
        {
            BackToTrain();
            return;
        }
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void ShowHideForwardButton()
    {
        if (currentPage == pages.Length - 1 || currentPage == 0)
        {
            forwardButton.gameObject.SetActive(false);
        }
        else
        {
            forwardButton.gameObject.SetActive(true);
        }
    }

    private void ShowCurrentPage()
    {
        foreach (RectTransform rt in pages)
        {
            rt.gameObject.SetActive(false);
        }
        pages[currentPage].gameObject.SetActive(true);
    }

    public void Category1()
    {
        currentPage = 1;
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void Category2()
    {
        currentPage = 2;
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void Category3()
    {
        currentPage = 3;
        ShowCurrentPage();
        ShowHideForwardButton();
    }
}
