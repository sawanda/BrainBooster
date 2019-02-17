using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game5Logic : MonoBehaviour
{
    public void BackToTrain() => SceneManager.LoadScene(GameSelectLogic.learnSceneName);
    public void BackToPlay() => SceneManager.LoadScene("Play");
    public Button forwardButton;
    public RectTransform[] pages;
    public int currentPage = 0;
    public UnityEvent endAction;

    public void StartAfterCoin  ()
    {
        Utility.correctCount = 0;
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

        var wp = pages[currentPage].GetComponent<Game5Page>();
        if(wp != null)
        {
            wp.ManualStart();
        }
    }
}
