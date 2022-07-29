using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScrollView : MonoBehaviour
{
    private Vector3 displayPos;     // The position of the card scroll view when it is displayed
    private Vector3 hiddenPos;     // The position of the card scroll view when it is hidden

    private Vector3 destPos;

    private bool needMoving = false;
    private float lastMoveTime = 0;


    private const float hiddenXDis = 3f;


    private const float moveTimeSpan = 0.05f;
    private const float disDeviation = 1e-6f;

    private void Start()
    {
        displayPos = transform.position;
        destPos = displayPos;
        hiddenPos = new Vector3(transform.position.x - hiddenXDis, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        MoveToDestPos();
    }

    public void Display()
    {
        ChangeDestPos(displayPos);
    }

    public void Hide()
    {
        ChangeDestPos(hiddenPos);
    }

    private void ChangeDestPos(Vector3 pos)
    {
        needMoving = true;
        destPos = pos;
    }

    private void MoveToDestPos()
    {
        // if there is no need to move card scroll view, return 
        if (!needMoving) return;

        // get current time
        float currTime = TimeManager.instance.GetCurrTime();

        // if current time is before scheduled time, return 
        if (currTime - lastMoveTime < moveTimeSpan) return;

        // if card scroll view is close to destination position, change its status
        if (Mathf.Abs(transform.position.x - destPos.x) <= disDeviation)
        {
            transform.position = destPos;
            needMoving = false;
            lastMoveTime = 0;
            return;
        }

        // else move card scroll view
        // x2 + (x2 - x1 ) * moveTimeSpan
        Vector3 newPos = transform.position;
        newPos.x += (destPos.x - transform.position.x) * moveTimeSpan * 2;
        transform.position = newPos;
        lastMoveTime = currTime;
    }
}