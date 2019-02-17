using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

[ExecuteAlways]
public class Waypoint : MonoBehaviour
{
    public WaypointNode[] nodes;

    public int currentLineProgress; 
    public int currentRedDotProgress; 
    public Vector3[] rememberCompleteLines;
    public bool won;
    public GameObject completeImage;
    public GameObject forHiding;
    public Animation completeAnimation;

[ContextMenu("@@#IJE@JI")]
    public void Haha()
    {
        for(int i = 0 ; i < rememberCompleteLines.Length; i++)
        {
            rememberCompleteLines[i] = new Vector3(rememberCompleteLines[i].x, rememberCompleteLines[i].y, 0);
        }
    }
   
    public void Dragged(BaseEventData baseEventData)
    {
        if(won) return;

        PointerEventData ped = (PointerEventData) baseEventData;
        Vector2 screenPosition = ped.position;

        for(int i = 0; i < nodes.Length; i++)
        {
            RectTransform rectTransform = nodes[i].waypointRect;
            bool contains = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPosition, Camera.main);
            //Debug.Log($"{screenPosition} ----> {rectTransform.rect} of {i} CONTAINS {contains}");
            if(contains && currentRedDotProgress == i)
            {
                currentRedDotProgress++;
                currentLineProgress = nodes[i].lineSegment;
            }
        }
    }

    public void Up()
    {
        if(won) return;

        currentLineProgress = 0;
        currentRedDotProgress = 0;
    }

    public void RememberLines()
    {
        rememberCompleteLines = new Vector3[lineRenderer.positionCount];
        var count = lineRenderer.GetPositions(rememberCompleteLines);
    }

    [ContextMenu("Remember")]
    public void Remember()
    {
        rememberCompleteLines = new Vector3[ lineRenderer.positionCount];
        lineRenderer.GetPositions(rememberCompleteLines);
    }


    [ContextMenu("Apply")]
    public void ApplyCurrentProgress()
    {
        List<Vector3> partialLine = new List<Vector3>();
        for(int i = 0; i <= currentLineProgress && i < rememberCompleteLines.Length; i++)
        {
            partialLine.Add(rememberCompleteLines[i]);
        }
        lineRenderer.positionCount = partialLine.Count;
        lineRenderer.SetPositions(partialLine.ToArray());
    }

    public void Update()
    {
        ApplyCurrentProgress();
        if (Application.isPlaying)
        {
            CheckForComplete();
        }
    }

    public void EnterPage()
    {
        won = false;
        currentLineProgress = 0;
        currentRedDotProgress = 0;
        completeImage.SetActive(false);
        forHiding.SetActive(true);
        Update();
    }

    private void CheckForComplete()
    {
        if(currentRedDotProgress == nodes.Length && won == false)
        {
            won = true;
            StartCoroutine(WinRoutine());
        }
    }

    IEnumerator WinRoutine()
    {
        completeAnimation.Play();
        yield return new WaitForSeconds(1);
        completeImage.SetActive(true);
        forHiding.SetActive(false);
    }

    [Space]
    public LineRenderer lineRenderer;
    public float radius;
    public int resolution = 100;

    [ContextMenu("Create Circle")]
    public void CreateCircle()
    {
        List<Vector3> collectPoint = new List<Vector3>();
        float diameter = radius * 2;
        float piece = diameter / (float)resolution;
        for (float y = radius; y > -radius; y -= piece)
        {
            float xSquared = (radius * radius) - (y * y);
            float x = Mathf.Sqrt(xSquared);
            collectPoint.Add(new Vector3(-x, y, 0));
        }

        List<Vector3> collectPointReversed = new List<Vector3>(collectPoint);
        collectPointReversed.Reverse();

        var collectPointReversedFlippedY = collectPointReversed.Select(a => new Vector3(-a.x, a.y));

        collectPoint.AddRange(collectPointReversedFlippedY);

        lineRenderer.positionCount = collectPoint.Count;
        lineRenderer.SetPositions(collectPoint.ToArray());
    }
}
