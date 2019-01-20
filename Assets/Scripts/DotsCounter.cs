using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class DotsCounter : MonoBehaviour
{
    [Range(0,10)]
    public int currentDots = 0;
    public GameObject dotPrefab;

    public void Update()
    {
        currentDots = Mathf.Clamp(currentDots, min: 0, max: 10);
        var difference = transform.childCount - currentDots;
        if(difference > 0)
        {
            for(int i = 0; i < difference; i++)
            {
                var child = transform.GetChild(0);
                GameObject.DestroyImmediate(child.gameObject);
            }
        }
        else if(difference < 0)
        {
            difference = Mathf.Abs(difference);
            for(int i = 0; i < difference; i++)
            {
                var go = GameObject.Instantiate(dotPrefab);
                go.transform.SetParent(transform);
                go.transform.localScale = Vector3.one;
            }
        }
    }
}
