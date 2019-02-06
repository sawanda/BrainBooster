using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class SoundObject : MonoBehaviour
{
    [TextArea]
    public string textOnBase;
    public AudioClip soundClip;
    public bool doNotPlayAnimation;

    [Space]

    public Animation touchAnimation;
    public TextMeshProUGUI baseText;
    public AudioSource audioSource;

    public void Update()
    {
        baseText.text = textOnBase;
        audioSource.clip = soundClip;
    }

    public void Touch()
    {
        audioSource.Play();
        if(doNotPlayAnimation == false)
        {
            touchAnimation.Play();
        }
    }
}
