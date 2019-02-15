using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform target;
    public float runningTime = 0.5f;
    public bool touched;
    public Animation ani;
    public bool wentIn;

    public void Touched()
    {
        if(!touched)
        {
            touched = true;
            StartCoroutine(RunningRoutine());
        }
    }

    Vector3 velo;
    IEnumerator RunningRoutine()
    {
        while (Vector3.Distance(transform.position, target.position) > 50f)
        {
            this.transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velo, runningTime);
            yield return null;
        }
        ani.Play();
        while(ani.isPlaying)
        {
            yield return null;
        }
        wentIn = true;
    }
}
