using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score_mode : MonoBehaviour
{
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI sexText;

    public Image BrainLeft;
    public Image BrainRight;
    public Image BrainLeft_avtive;
    public Image BrainRight_avtive;

    public void updateAgeandSex() 
    {
        GameSave gameSave = GameSaveManager.ActiveSave;
        ageText.text = gameSave.age.ToString();
        sexText.text = gameSave.sex.ToString();

        if(gameSave.LeftDominant)
        {
            BrainLeft_avtive.enabled=true;
            
        }else 
        {
            BrainLeft_avtive.enabled=false;   
        }

        if(gameSave.RightDominant)
        {
            BrainRight_avtive.enabled=true;
            
        }else 
        {
            BrainRight_avtive.enabled=false;   
        }

        
        
    }

}
