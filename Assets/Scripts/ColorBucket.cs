using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BucketColor 
{
    Red = 0,
    Blue = 1,
    Yellow = 2,
    Green = 3
}

[ExecuteAlways]
public class ColorBucket : MonoBehaviour
{
    public BucketColor bucketColor;
    public Sprite[] bucketSprites;
    public Image image;
    public AudioSource soundWhenPressed;

    public void GoInvisible()
    {
        image.enabled = false;
    }

    public void ChangeColorOfOtherBucketToTheSameOfThisOne(ColorBucket otherBucket)
    {
        //Debug.Log("Change");
        soundWhenPressed.Play();
        otherBucket.image.enabled = true;
        otherBucket.bucketColor = this.bucketColor;
    }

    public void Update()
    {
        switch (bucketColor)
        {
            case BucketColor.Red:
                image.sprite = bucketSprites[0];
                break;
            case BucketColor.Blue:
                image.sprite = bucketSprites[1];
                break;
            case BucketColor.Yellow:
                image.sprite = bucketSprites[2];
                break;
            case BucketColor.Green:
                image.sprite = bucketSprites[3];
                break;
        }
    }
}
