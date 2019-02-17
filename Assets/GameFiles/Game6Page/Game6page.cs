using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6page : MonoBehaviour
{
    public int answer;
    public Game5Logic game5Logic;

    public void Answer(int theAnswer)
    {
        if(answer == theAnswer)
        {
            Utility.correctCount++;
            game5Logic.Forward();
        }
        else
        {
            game5Logic.Forward();
        }
    }
}
