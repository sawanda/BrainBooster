using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class Bucket : MonoBehaviour
{
    public bool activated;
    public Sprite activatedSprite;
    public Sprite deactivatedSprite;
    public Image image;
    public Game1Logic logic;
    public Bucket[] allBuckets;

    void Update()
    {
        image.sprite = activated ? activatedSprite : deactivatedSprite;
    }

    private void AllBucketGrey()
    {
        foreach(Bucket b in allBuckets)
        {
            b.activated = false;
        }
    }

    private void ThisBucketRed()
    {
        this.activated = true;
    }

    public void ClickBucket1()
    {
        logic.ChangeStage(Game1Logic.PlayStage.Stage1);
        AllBucketGrey();
        ThisBucketRed();
    }


    public void ClickBucket2()
    {
        logic.ChangeStage(Game1Logic.PlayStage.Stage2);
        AllBucketGrey();
        ThisBucketRed();
    }

    public void ClickBucket3()
    {
        logic.ChangeStage(Game1Logic.PlayStage.Stage3);
        AllBucketGrey();
        ThisBucketRed();
    }

}
