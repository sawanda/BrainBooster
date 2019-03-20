using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game8Logic : MonoBehaviour
{
    public void BackToPlay() => SceneManager.LoadScene(GameSelectLogic.learnSceneName);

    public ColorBucket followerBucket;
    public MixingBucket mixingBucket;
    public RectTransform mainRectangle;
    public Camera mainCamera;

    public GraphicRaycaster raycaster;
    public PlayableDirector tutorialDirector;

    public GameObject [] hint;

    ColorProblem currentProblem;
    
    int score;
    int round;
    bool wrongOnce = false;

    public Animation correctAnimation;
    public Animation wrongAnimation;
    public Result result;

    public void CheckColor(BucketColor color1, BucketColor color2)
    {
        ColorProblem mixedColor = MixBucketColor(color1, color2);

        if (mixedColor == currentProblem)
        {
            if (wrongOnce == false)
            {
                score++;
            }

            correctAnimation.Play();

            round = round + 1;
            if (round == 5)
            {
                EndGame();
            }
            else
            {
                CreateProblem();
            }
        }
        else
        {
            wrongAnimation.Play();
            wrongOnce = true;
        }
    }

    private void EndGame()
    {
        ScoreAll.Score = score;
        result.Show();
    }

    private ColorProblem MixBucketColor(BucketColor color1, BucketColor color2)
    {
        if (color1 == BucketColor.Red && color2 == BucketColor.Yellow)
        {
            return ColorProblem.Orange;
        }
        if (color1 == BucketColor.Yellow && color2 == BucketColor.Red)
        {
            return ColorProblem.Orange;
        }
        if (color1 == BucketColor.Blue && color2 == BucketColor.Yellow)
        {
            return ColorProblem.Green;
        }
        if (color1 == BucketColor.Yellow && color2 == BucketColor.Blue)
        {
            return ColorProblem.Green;
        }
        if (color1 == BucketColor.Blue && color2 == BucketColor.Red)
        {
            return ColorProblem.Purple;
        }
        if (color1 == BucketColor.Red && color2 == BucketColor.Blue)
        {
            return ColorProblem.Purple;
        }
        throw new Exception();
    }

    public enum ColorProblem {
        Green = 0,
        Orange = 1,
        Purple = 2
    }

    public void Start()
    {
        CreateProblem();
        StartCoroutine(TutorialRoutine());
    }

    private void CreateProblem()
    {
        wrongOnce = false;
        currentProblem = (ColorProblem)UnityEngine.Random.Range(0, 3);

        GameObject h1 = hint[0];
        GameObject h2 = hint[1];
        GameObject h3 = hint[2];

        if (currentProblem == ColorProblem.Green)
        {
            h1.SetActive(true);
            h2.SetActive(false);
            h3.SetActive(false);
        }
        else if (currentProblem == ColorProblem.Orange)
        {
            h1.SetActive(false);
            h2.SetActive(true);
            h3.SetActive(false);
        }
        else if (currentProblem == ColorProblem.Purple)
        {
            h1.SetActive(false);
            h2.SetActive(false);
            h3.SetActive(true);
        }

        mixingBucket.Reset();
    }

    IEnumerator TutorialRoutine()
    {
        yield return new WaitForSeconds(2);

        raycaster.enabled = false;
        tutorialDirector.Play();
        yield return new WaitForSeconds((float)tutorialDirector.playableAsset.duration);
        raycaster.enabled = true;
        tutorialDirector.Stop();

        mixingBucket.Reset();
    }

    public void Dragging(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData) bed;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(mainRectangle, ped.position, null, out Vector3 answer);
        followerBucket.transform.position = answer;
    }

    public void EndDrag(BaseEventData baseEventData)
    {
        followerBucket.GoInvisible();
        PointerEventData ped = (PointerEventData) baseEventData;
        bool isInRect = RectTransformUtility.RectangleContainsScreenPoint(mixingBucket.GetComponent<RectTransform>(), ped.position);
        if(isInRect)
        {
            mixingBucket.Drop();
            if (mixingBucket.mixedColor.Count == 2)
            {
                StartCoroutine(MixedRoutine());
            }
        }
    }

    IEnumerator MixedRoutine()
    {
        
        raycaster.enabled = false;
        yield return new WaitForSeconds(3);
        mixingBucket.Reset();
        raycaster.enabled = true;
    }
}
