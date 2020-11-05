using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]

public class ReticleUI : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject = null;

    private RectTransform uiImage;
    private  Rigidbody rbody;

    Vector3 lb, rt, lt, rb;
    float distance;
    void Start()
    {   
        // this.startWorldPointX = Camera.main.ViewportToWorldPoint(0,0,1);
        rbody = GetComponent<Rigidbody>();
        uiImage = GetComponent<RectTransform>();
    }
 
    void Update()
    {
        uiImage.position
            = RectTransformUtility.
            WorldToScreenPoint(Camera.main,targetObject.position);
        if(uiImage.position.y <  10.0f ){
            Vector3 pos_temp = uiImage.position;
            pos_temp.y = 10.0f;
            uiImage.position = pos_temp;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(uiImage.position);
        }
    }
}