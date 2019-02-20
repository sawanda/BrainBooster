using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Game5State
{
    Wait,
    Shake,
}

public class Game5Page : MonoBehaviour
{
    public Game5Choice[] choices;
    public Game5Choice currentChoice;
    public Animator animator;
    public Game5State state;
    public Game5Logic logic;

    public int[] bag;
    public int currentRound = 0;
    public int currentRandomize;

    public void ManualStart()
    {
        bag = new int[] { 0, 1, 2 };
        Shuffle(bag);
        StartRound();
    }

    public void StartRound()
    {
        StartCoroutine(StartRoundRoutine());
    }

    IEnumerator StartRoundRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        currentRandomize = bag[currentRound];
        currentChoice = choices[currentRandomize];
        animator.SetTrigger("Instruction");

        yield return new WaitForSeconds(2);

        state = Game5State.Shake;
        currentShake = 0;
        previousFrameShake = Input.acceleration;
    }

    const float shakeRequired = 20;
    public float currentShake = 0;
    public AudioSource audioPlayer;
    public Vector3 previousFrameShake;
    public void Update()
    {
        if (state == Game5State.Shake)
        {
            Vector3 thisFrameShake = Input.acceleration;
            float shakeBy = Vector3.Distance(previousFrameShake, thisFrameShake);
            previousFrameShake = thisFrameShake;
            Debug.Log("Shake by " + shakeBy);

            if (shakeBy > 0.1f)
            {
                currentShake += shakeBy;
                if (currentShake > shakeRequired)
                {
                    animator.SetTrigger("Shake");
                    audioPlayer.clip = currentChoice.sound;
                    audioPlayer.Play();
                    currentShake = 0;
                }
            }
        }
    }
    public bool WrongBefore;
    public void Answer(Game5Choice choice5)

    {
        int correctAnswer = currentRandomize;
        if ( choice5.Answer== correctAnswer)
        {  
            
           currentRound++;
           if(!WrongBefore){
               ScoreAll.Score++;
           }
            if (currentRound > 2)
            {
        
                logic.Forward();
            }
            else
            {
                
                state = Game5State.Wait;
                StartCoroutine(WinRoutine());
            }
        }
        else{
            WrongBefore = true;
            choice5.GetComponent<Animation>().Play();

        }
    }

    public Image gift;

    IEnumerator WinRoutine()
    {
        Sprite giftBox = gift.sprite;
        gift.sprite = currentChoice.answerImage;
        yield return new WaitForSeconds(1);
        gift.sprite = giftBox;
        StartRound();
    }

    public void Shuffle(int[] array)
    {
        System.Random random = new System.Random();
        int n = array.Count();
        while (n > 1)
        {
            n--;
            int i = random.Next(n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }
    }
}
