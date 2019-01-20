using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1Logic : MonoBehaviour
{
    public enum PlayStage
    {
        Stage1,
        Stage2,
        Stage3
    }

    [SerializeField] 
    private PlayStage currentStage;


    public GraphicRaycaster raycaster;
    [Space]
    public DotsCounter smallDotCounter;
    public DotsCounter bigDotCounter;
    public TextMeshProUGUI dotNumber;
    [Space]
    public PlayableDirector tutorialDirector;
    public PlayableDirector correctDirector;
    [Space]
    public AudioClip[] numberSounds;
    public AudioSource numberSoundSource;

    public int currentProblem;

    void Start() 
    {
        RandomProblem();
        ChangeStage(PlayStage.Stage1);
        SetDotAndNumber(0);
        StartCoroutine(TutorialRoutine());
    }

    public void BackToTrain() => SceneManager.LoadScene(GameSelectLogic.learnSceneName);

    public void ChangeStage(PlayStage changeTo) 
    {
        currentStage = changeTo;
        SetDotAndNumber(0);
    }

    void Update()
    {
        if(currentStage == PlayStage.Stage3)
        {
            SetDotAndNumber(currentProblem);
        }
    }

    private int finger = 0;

    public void SandDown()
    {
        finger++;
        TouchSandbox(finger);
    }

    public void SandUp()
    {
        finger--;
        TouchSandbox(finger);
    }

    public void TouchSandbox(int fingerCount)
    {
        //Debug.Log(fingerCount);

        if (correctDirector.state != PlayState.Playing)
        {
            PlayNumberSound(fingerCount);
        }

        switch (currentStage)
        {
            case PlayStage.Stage1:
            case PlayStage.Stage2:
                SetDotAndNumber(fingerCount);
                break;
            case PlayStage.Stage3:
                CheckAndChangeProblem(fingerCount);
                break;
        }
    }

    private void CheckAndChangeProblem(int fingerCount)
    {
        if(fingerCount == currentProblem)
        {
            StartCoroutine(CorrectRoutine());
        }
    }

    IEnumerator CorrectRoutine()
    {
        raycaster.enabled = false;
        correctDirector.Stop();
        correctDirector.Play();
        yield return new WaitForSeconds((float)correctDirector.playableAsset.duration);
        RandomProblem();
        raycaster.enabled = true;
    }

    IEnumerator TutorialRoutine()
    {
        raycaster.enabled = false;
        SetDotAndNumber(10);
        tutorialDirector.Play();
        yield return new WaitForSeconds((float)tutorialDirector.playableAsset.duration);
        SetDotAndNumber(0);
        raycaster.enabled = true;
    }

    public void PlayNumberSound(int number)
    {
        if(number >= numberSounds.Length) return;
        numberSoundSource.PlayOneShot(numberSounds[number]);
    }

    public void RandomProblem() => currentProblem = Random.Range(1, 11);

    public void SetDotAndNumber(int count)
    {
        switch (currentStage)
        {
            case PlayStage.Stage1:
                smallDotCounter.currentDots = count;
                bigDotCounter.currentDots = 0;
                dotNumber.text = count.ToString();
                break;
            case PlayStage.Stage2:
                smallDotCounter.currentDots = 0;
                bigDotCounter.currentDots = count;
                dotNumber.text = "";
                break;
            case PlayStage.Stage3:
                smallDotCounter.currentDots = 0;
                bigDotCounter.currentDots = 0;
                dotNumber.text = count.ToString();
                break;
        }
    }

}
