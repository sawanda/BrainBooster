using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PaintState
{
    Normal,
    Brush,
    Eraser
}

public class PaintLogic : MonoBehaviour
{

    public void BackToPlay() => SceneManager.LoadScene("Play");
    public PaintState paintState;
    public GameObject brush;
    public GameObject eraser;
    public Color selectedColor;
    public ColorPalette[] colorPalettes;

    public RenderTexture paintingTexture;
    

    [ContextMenu("Save Image")]
    public void SaveImage()
    {
        
        var saved = RenderTexture.active;
        RenderTexture.active = paintingTexture;

        Texture2D t2d = new Texture2D(paintingTexture.width, paintingTexture.height, TextureFormat.ARGB32, mipChain: false);
        t2d.ReadPixels(new Rect(0, 0, paintingTexture.width, paintingTexture.height), 0, 0);

        RenderTexture.active = saved;

        byte[] pngBytes = t2d.EncodeToPNG();

        Debug.Log("SAVING " + Application.persistentDataPath);
        File.WriteAllBytes(Application.persistentDataPath + "/test.png", pngBytes);
        
    }

    public void BrushTouched()
    {
        paintState = PaintState.Brush;
        brush.SetActive(false);
        eraser.SetActive(true);
    }

    public void EraserTouched()
    {
        paintState = PaintState.Eraser;
        brush.SetActive(true);
        eraser.SetActive(false);
        selectedColor = Color.white;
        foreach(ColorPalette cp in colorPalettes)
        {
            cp.Deselect();
        }
    }

    public void SelectColor(ColorPalette selectedPalette)
    {
        if(paintState == PaintState.Eraser)
        {
            return;
        }

        selectedColor = selectedPalette.color;
        foreach(ColorPalette cp in colorPalettes)
        {
            cp.Deselect();
        }
        selectedPalette.Select();
    }

    public Transform problemParent;
    public Transform hintParent;

    [ContextMenu("DFDAFDAAFS")]
    public void Test()
    {
        StartPainting(FindObjectOfType<PictureCard>());
    }

    PictureProblem pp;
    PictureCard selectedCard;

    GameObject createdProblem;
    GameObject createdHint;

    public void StartPainting(PictureCard pc)
    {
        selectedCard = pc;
        createdProblem = Instantiate(pc.problem, Vector3.zero, Quaternion.identity, problemParent);
        createdProblem.transform.localPosition = Vector3.zero;

        pp = createdProblem.GetComponent<PictureProblem>();
        GameObject hint = pp.hint;
        createdHint = Instantiate(hint, Vector3.zero, Quaternion.identity, hintParent);
        createdHint.transform.localPosition = Vector3.zero;

        pp.GoWhite();
    }

    public void DestroyProblem()
    {
        Destroy(createdProblem);
        Destroy(createdHint);
    }

    public void Submit()
    {
        if(pp.IsCorrect())
        {
            Debug.Log("CORRECT");
            selectedCard.Pass();
        }
        else
        {
            //...
        }
    }
}
