using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Projectile : MonoBehaviour
{
    
    private SpringJoint2D sj;
    private Rigidbody2D rb;

    [Header("弹射设置")]
    public float maxDis;
    public float minDis;
    public Transform anchor;

    [Space]


    private bool isClicked = false;
    private bool isProjected = false;
    private Vector3 originalPos;

    private bool test = true;

    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
        isClicked = false;
        sj.enabled = true;
        isProjected = false;
        //anchorPos = new Vector3(sj.connectedAnchor.x, sj.connectedAnchor.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithMouse();
    }

    public void Project()
    {
        //通知减费
        GameManager.instance.CutCost(gameObject);
        sj.enabled = false;
        isProjected = true;
    }

    private void MoveWithMouse()
    {
        if(isClicked )
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            //limit the distant
            if(Vector2.Distance(transform.position, anchor.position) >= maxDis)
            {
                transform.position = anchor.position + (transform.position - anchor.position).normalized * maxDis;
            }

        }
    }
    private void OnMouseDown() {
        if(isProjected)
            return;
        isClicked = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() {
        isClicked = false;
        rb.isKinematic = false;
        if(false && Vector2.Distance(transform.position, anchor.position) <= minDis)
        {
            transform.position = originalPos;
        }
        else
        {
            Invoke(nameof(Project), 0.12f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(test)
            GameObject.Instantiate(gameObject, originalPos, Quaternion.identity);
            test = false;
    }
    private void OnDestroy() {

    }

    
}