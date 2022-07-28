using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScrollView : MonoBehaviour
{
    private Vector3 displayPos;     // The position of the card scroll view when it is displayed
    private Vector3 hiddenPos;     // The position of the card scroll view when it is hidden


    private void Start()
    {
        displayPos = transform.position;
        hiddenPos = new Vector3(transform.position.x - 10f, transform.position.y, transform.position.z);
    }

    public void Display()
    {
        transform.position = displayPos;
        // if (transform.position.x < displayPos.x)
        // {
        //     transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        //     Invoke("Display", 0.1f);
        // }
        // else transform.position = displayPos;
    }

    public void Hide()
    {
        transform.position = hiddenPos;
        // if (transform.position.x > hiddenPos.x)
        // {
        //     transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        //     Invoke("Hide", 0.1f);
        // }
        // else transform.position = hiddenPos;
    }
}