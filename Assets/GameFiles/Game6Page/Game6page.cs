using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6page : MonoBehaviour
{
    public int answer;
    public Game5Logic game5Logic;
    public bool WrongBefore;
    public Animation correctAnimation;
    public Animation wrongAnimation;
    public void Answer(Game5Choice Choice5){
       if(answer == Choice5.Answer)
        {

            if(!WrongBefore)
            {
               ScoreAll.Score++;
               
            }
        
            game5Logic.Forward();
            
            
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
