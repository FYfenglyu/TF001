using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        PlayManager.instance.birthDoor  = gameObject;  
        PlayManager.instance.originalPos = gameObject.transform.position;
    }
    //public GameObject hunter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
