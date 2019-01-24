using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MixingBucket : MonoBehaviour
{
    public List<BucketColor> mixedColor = new List<BucketColor>(2);

    public ColorBucket followerBucket;
    public TextMeshProUGUI number;

    public Image circleColor;

    public Color[] possibleColors; //6
    public AudioClip[] soundOfColors; //6
    public AudioSource audioSource;

    public void Drop()
    {
        if (mixedColor.Count < 2)
        {
            mixedColor.Add(followerBucket.bucketColor);
            number.text = (2 - mixedColor.Count).ToString();
            MixColor();
        }
    }

    public void Reset()
    {
        mixedColor.Clear();
        number.text = "2";
        MixColor();
    }

    private void MixColor()
    {
        if (mixedColor.Count == 0)
        {
            circleColor.color = Color.white;
        }
        else if (mixedColor.Count == 1)
        {
            circleColor.color = possibleColors[((int)mixedColor[0]) + 6];
        }
        else if (mixedColor.Count == 2)
        {
            if(mixedColor.Contains(BucketColor.Red) && mixedColor.Contains(BucketColor.Blue))
            {
                circleColor.color = possibleColors[0];
                audioSource.clip = soundOfColors[0];
                audioSource.Play();
            }
            else if(mixedColor.Contains(BucketColor.Red) && mixedColor.Contains(BucketColor.Yellow))
            {
                circleColor.color = possibleColors[1];
                audioSource.clip = soundOfColors[1];
                audioSource.Play();
            }
            else if(mixedColor.Contains(BucketColor.Red) && mixedColor.Contains(BucketColor.Green))
            {
                circleColor.color = possibleColors[2];
                audioSource.clip = soundOfColors[2];
                audioSource.Play();
            }
            else if(mixedColor.Contains(BucketColor.Blue) && mixedColor.Contains(BucketColor.Yellow))
            {
                circleColor.color = possibleColors[3];
                audioSource.clip = soundOfColors[3];
                audioSource.Play();
            }
            else if(mixedColor.Contains(BucketColor.Blue) && mixedColor.Contains(BucketColor.Green))
            {
                circleColor.color = possibleColors[4];
                audioSource.clip = soundOfColors[4];
                audioSource.Play();
            }
            else if(mixedColor.Contains(BucketColor.Yellow) && mixedColor.Contains(BucketColor.Green))
            {
                circleColor.color = possibleColors[5];
                audioSource.clip = soundOfColors[5];
                audioSource.Play();
            }
            
        }
    }
}
