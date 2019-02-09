using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsLogic : MonoBehaviour
{
    public int currentPage;
    public GameSave[] allPlayers;

    public GameSaveView[] gameSaveViews;
    
    public Button nextButton;
    public Button previousButton;

    public int PageNeeded => Mathf.CeilToInt(allPlayers.Length / 4f);

    public class CompareByDate : IComparer<GameSave>
    {
        public int Compare(GameSave a, GameSave b)
        {
            return a.startPlayingTime.Ticks.CompareTo(b.startPlayingTime.Ticks);
        }
    }

    public void GoToNaming() 
    {
        NamingLogic.GoToNaming(nextScene: "GameSelect", backScene: "Stats");
    }

    public void Start()
    {
        var saves = GameSaveManager.ReadAllSaves().ToList();
        saves.Sort(new CompareByDate());
        allPlayers = saves.ToArray();

        ShowCurrentPage();
    }

    public void PreviousPage()
    {
        currentPage--;
        ClampCurrentPage();
        ShowCurrentPage();
    }

    public void NextPage()
    {
        currentPage++;
        ClampCurrentPage();
        ShowCurrentPage();
    }

    private void ClampCurrentPage()
    {
        currentPage = Mathf.Clamp(currentPage, 0, PageNeeded);
    }

    public void ShowCurrentPage()
    {
        GameSave[] saves = SavesOfCurrentPage(); //1 2 3

        foreach(GameSaveView gsv in gameSaveViews)
        {
            gsv.Hide();
        }

        for (int i = 0; i < saves.Length; i++)
        {
            gameSaveViews[i].DisplayGameSave(saves[i]);
        }

        if(currentPage == 0)
        {
            previousButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
        else if(currentPage == PageNeeded)
        {
            previousButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }

    private GameSave[] SavesOfCurrentPage()
    {
        List<GameSave> answer = new List<GameSave>();
        for (int i = currentPage * 3; //Start
        (i <= (currentPage * 3) + 2) && (i < allPlayers.Length); //Condition
         i++) //Plus
        {
            answer.Add(allPlayers[i]);
        }
        return answer.ToArray();
    }

}
