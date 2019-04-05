using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game9page : MonoBehaviour
{
    public int answer;
    public Game9NumberLogic game9NumberLogic;
    public bool WrongBefore;
    public void Answer(Game5Choice Choice5){
       if(answer == Choice5.Answer)
        {

            if(!WrongBefore)
            {
               ScoreAll.Score++;
            }

            game9NumberLogic.Forward();
            
        }
        else
        {   
            WrongBefore = true; 
           // game5Logic.Forward();
            Choice5.GetComponent<Animation>().Play();
        }
    }
    // public void Answer(int theAnswer)
    // {
    //     if(answer == theAnswer)
    //     {
    //         Utility.correctCount++;
    //         game5Logic.Forward();
    //     }
    //     else
    //     {
    //         game5Logic.Forward();
    //     }
    // }
}
