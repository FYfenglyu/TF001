using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Vector2 MouseClickPos2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Debug.Log("Clicked.");

        // 记录下鼠标点击时的坐标
        MouseClickPos2D = GetMousePos2D();
    }

    private void OnMouseUp()
    {
        // Debug.Log("Unclicked.");

        // 记录下鼠标松开时的位置
        // 如果鼠标松开时的位置和点击时的位置一致，判定为选中卡牌

        // 更新：
        // 如果鼠标点击时和松开时在同一张卡牌上，则选中该卡牌
        // ***********（待解决）

        Vector2 MouseUnclickPos2D = GetMousePos2D();

        if(MouseClickPos2D == MouseUnclickPos2D)
        {
            Debug.Log("Card Choosen.");

            // 卡牌被选中
            // GameController.SetCurrCard()
        }
    }

    private Vector2 GetMousePos2D()
    {
        Vector3 Pos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Pos2D = new Vector2(Pos3D.x, Pos3D.y);

        return Pos2D;
    }
}
