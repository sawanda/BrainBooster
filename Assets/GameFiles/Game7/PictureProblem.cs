using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PictureProblem : MonoBehaviour
{
    public ColoringElement[] allPieces;
    public GameObject hint;

    public bool IsCorrect()
    {
        return allPieces.All( x => x.answer == x.GetComponent<Image>().color);
    }

    public void GoWhite()
    {
        foreach(ColoringElement ce in allPieces)
        {
            ce.GetComponent<Image>().color = Color.white;
        }
    }
}
