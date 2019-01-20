using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteAlways]
public class BoundedController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float relativePosition;
    [Range(0f, 5f)]
    public float sensitivity = 1;

    public float preventClickThreshold;
    public bool preventClick = false;

    public Transform leftBound;
    public Transform rightBound;
    public Physics2DRaycaster trainRaycaster;

    void Update()
    {
        Vector3 lerpedPosition = Vector3.Lerp(leftBound.position, rightBound.position, relativePosition);

        transform.position = lerpedPosition;
    }

    public void Clicked(BaseEventData baseEventData)
    {
        if(!preventClick)
        {
            //Debug.Log(nameof(Clicked));
            PointerEventData ped = (PointerEventData)baseEventData;
            List<RaycastResult> result = new List<RaycastResult>();
            trainRaycaster.Raycast(ped, result);
            //Debug.Log($"Hitted {result.Count}");
            if(result.Count > 0)
            {
                RaycastResult firstHit = result[0];
                var et = firstHit.gameObject.GetComponent<EventTrigger>();
                et.OnPointerClick(ped);
            }
        }
        preventClick = false;
    }

    public void Dragged(BaseEventData baseEventData)
    {
        PointerEventData ped = (PointerEventData)baseEventData;
        Vector2 delta = ped.delta;
        relativePosition -= delta.x * sensitivity * 0.001f;
        relativePosition = Mathf.Clamp01(relativePosition);

        if (Mathf.Abs(delta.x) > preventClickThreshold)
        {
            preventClick = true;
        }
    }
}
