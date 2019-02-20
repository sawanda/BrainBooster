using UnityEngine;
using UnityEngine.UI;

public class PictureCard  : MonoBehaviour
{
    public GameObject problem;
    public bool passed;
    public Image completeImage;
    public Image cardWithRabbit;
    public Image card;
    public PaintLogic cardLogic;
    public Image cardWhite;


    public void Pass()
    {
        passed = true;
        completeImage.enabled = true;

        cardWithRabbit.enabled = false;
        card.enabled = true;
        cardWhite.enabled = true;
    }
    public void Click(){
        Debug.Log("Click");
        cardLogic.StartPainting(this);
    }
}
