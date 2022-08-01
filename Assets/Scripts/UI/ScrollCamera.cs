using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour 
{
    //刚接触屏幕时的点
    private Vector2 oldScreenpoint;
    //记录单指移动变化量
    private Vector2 v;
    //定义照相机
    private Camera mainCamera;
    //定义照相机的位置
    private Vector3 mainCameraPosition;
    //单指移动速度
    public float MoveSpeed = -1f;
    //x,y平面限制的移动区域，通过计算得出结果
    private float xMin = 0f; //手机右边缘，绝对值越大越靠近
    private float xMax = f; //手机左边缘
    // Use this for initialization
    void Start()
    {
        //找到相机组件
        mainCamera = GetComponent<Camera>();
        //获取相机的位置
        mainCameraPosition = mainCamera.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //当单指触摸时
        if (Input.touchCount == 1)
        {
            //单指刚接触屏幕时
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //记录接触点
                oldScreenpoint = Input.GetTouch(0).position;
            }
            //当单指移动时
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //记录x轴移动变化量
                v.x = Input.GetTouch(0).deltaPosition.x * Time.deltaTime;
                //改变相机的位置（此时相机不移动）
                mainCameraPosition += new Vector3(v.x, 0, 0) * MoveSpeed;
                //限制相机的移动范围, -14.79633f是镜头离物体的距离
                mainCameraPosition = new Vector3(Mathf.Clamp(mainCameraPosition.x, xMin, xMax), 0, -14.79633f);
                //移动相机到对应的位置（此时相机才能移动）
                this.transform.position = mainCameraPosition;
            }
        }
    }
}
