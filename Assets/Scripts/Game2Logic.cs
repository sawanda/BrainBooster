using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2Logic : MonoBehaviour
{
    public void BackToTrain() => SceneManager.LoadScene(GameSelectLogic.learnSceneName);

    public ColorBucket followerBucket;
    public MixingBucket mixingBucket;
    public RectTransform mainRectangle;
    public Camera mainCamera;

    public GraphicRaycaster raycaster;
    public PlayableDirector tutorialDirector;

    public void Start()
    {
        mixingBucket.Reset();
        StartCoroutine(TutorialRoutine());
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
