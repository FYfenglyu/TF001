using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour 
{
    [Header("相机是否可以横向移动")]
    public bool isXScrollable = false;

    [Header("横向背景")]
    public GameObject horizonBG;

    private Vector2 mouseWordPos, mouseStartPos;
    private Vector2 cameraStartPos;
    private float distance;

    Camera cam;

    private float coef;
    private float maxLeftDis;
    private float maxRightDis;

    private void Awake()
    {
        AdjustScreenScale();
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
        
        coef = Screen.height / cam.orthographicSize / 2;

        // maxLeftDis = 
    }

    private void Update()
    {
        if(isXScrollable) OnXScrollable();
    }

    private void OnXScrollable()
    {
        // get world postion of mouse
        mouseWordPos = GetWorldPos2D(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            mouseStartPos = mouseWordPos;
            cameraStartPos = transform.position;
        }

        if(Input.GetMouseButton(0))
        {
            distance = mouseWordPos.x - mouseStartPos.x;
            mouseStartPos = mouseWordPos;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - distance,0,12.5f),
            transform.position.y,transform.position.z);
        }
    }

    Vector2 GetWorldPos2D(Vector2 pos)
    {
        return new Vector2((pos.x-Screen.width/2f)/coef, (pos.y -Screen.height/2f)/coef);
    }

    public static void AdjustScreenScale()
    {
        // to edit
        float DevelopWidth = 1920f;
        float DevelopHeigh = 1080f;
        float DevelopRate = DevelopHeigh / DevelopWidth;
        int curScreenHeight = Screen.height;
        int curScreenWidth = Screen.width;

        float ScreenRate = (float)Screen.height / (float)Screen.width;

        float cameraRectHeightRate = DevelopHeigh / ((DevelopWidth / Screen.width) * Screen.height);
        float cameraRectWidthRate = DevelopWidth / ((DevelopHeigh / Screen.height) * Screen.width);

        if (DevelopRate <= ScreenRate)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, (1 - cameraRectHeightRate) / 2, 1, cameraRectHeightRate);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect((1 - cameraRectWidthRate) / 2, 0, cameraRectWidthRate, 1);
        }
    }
}