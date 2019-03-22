using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Graph : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform color_1;
    public RectTransform color_2;
    public RectTransform number_1;
    public RectTransform number_2;
    public RectTransform shape_1;
    public RectTransform shape_2;
    public RectTransform sound_1;
    public RectTransform sound_2;


    public void AdjustHeight()
    {
        GameSave gameSave = GameSaveManager.ActiveSave;
        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game5Score.first);
            var bbb = Mathf.Lerp(0, 460, aaa);
            color_1.sizeDelta = new Vector2(color_1.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game5Score.latest);
            var bbb = Mathf.Lerp(0, 460, aaa);
            color_2.sizeDelta = new Vector2(color_2.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game6Score.first);
            var bbb = Mathf.Lerp(0, 460, aaa);
            number_1.sizeDelta = new Vector2(number_1.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game6Score.latest);
            var bbb = Mathf.Lerp(0, 460, aaa);
            number_2.sizeDelta = new Vector2(number_2.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game9Score.first);
            var bbb = Mathf.Lerp(0, 460, aaa);
            shape_1.sizeDelta = new Vector2(shape_1.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game9Score.latest);
            var bbb = Mathf.Lerp(0, 460, aaa);
            shape_2.sizeDelta = new Vector2(shape_2.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game10Score.first);
            var bbb = Mathf.Lerp(0, 460, aaa);
            sound_1.sizeDelta = new Vector2(sound_1.sizeDelta.x, bbb);
        }

        {
            var aaa = Mathf.InverseLerp(0, 5, gameSave.game10Score.latest);
            var bbb = Mathf.Lerp(0, 460, aaa);
            sound_2.sizeDelta = new Vector2(sound_2.sizeDelta.x, bbb);
        }

    }
}
