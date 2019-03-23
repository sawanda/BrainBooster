
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game9NumberLogic : MonoBehaviour
{
    public void BackToTrain() => SceneManager.LoadScene(GameSelectLogic.learnSceneName);
    public void BackToPlay() => SceneManager.LoadScene("Play");
    public Button forwardButton;
    public RectTransform[] pages;
    public int currentPage = 0;
    public UnityEvent endAction;

    public void resetscore (){
        for (int i = 0; i < pages.Length; i++)
        {

          game9page reset =  pages[i].gameObject.GetComponent<game9page>();
          reset.WrongBefore = false;
        }
    }

    public void Random(){
        pages = pages.OrderBy( a=> Guid.NewGuid()).ToArray();
    }

    public void StartAfterCoin  ()
    {
        ScoreAll.Score = 0;
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void Forward()
    {
        currentPage++;
        if (currentPage == pages.Length)
        {
            endAction.Invoke();
        }
        else
        {
            ShowCurrentPage();
            ShowHideForwardButton();
        }
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

    public void FirstPage()
    {
        currentPage = 0;
        ScoreAll.Score = 0;
        ShowCurrentPage();
        ShowHideForwardButton();
    }

    public void ShowHideForwardButton()
    {
        if (currentPage == pages.Length - 1 )
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

        // var wp = pages[currentPage].GetComponent<game9page>();
        // if(wp != null)
        // {
        //     wp.ManualStart();
        // }
    }
}