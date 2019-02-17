using UnityEngine;
using UnityEngine.UI;

public class PictureCard  : MonoBehaviour
{
    public GameObject problem;
    public bool passed;
    public Image completeImage;
    public Image cardWithRabbit;
    public Image card;

    public void Pass()
    {
        passed = true;
        completeImage.enabled = true;

        cardWithRabbit.enabled = false;
        card.enabled = true;
    }
}
