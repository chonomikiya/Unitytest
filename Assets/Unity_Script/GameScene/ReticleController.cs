using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]

public class ReticleController : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject = null;

    private RectTransform uiImage;
    private  Rigidbody rbody;
    public float speed = 0.05f;
    public  Vector3 startWorldPointX;
    public  float endWorldPointX;
    public  float startWorldPointY;
    public  float endWorldPointY; 

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
        // distance = Vector3.Distance(transform.position,targetObject.position);
        // lb = Camera.main.ViewportToWorldPoint( new Vector3(0, 0, distance));
		// rt = Camera.main.ViewportToWorldPoint( new Vector3(1, 1, distance));
		// lt = new Vector3( lb.x, rt.y, lb.z);
		// rb = new Vector3( rt.x, lb.y, rt.z);
        uiImage.position
            = RectTransformUtility.
            WorldToScreenPoint(Camera.main,targetObject.position);
        if(uiImage.position.y <  10.0f ){
            Vector3 pos_temp = uiImage.position;
            pos_temp.y = 10.0f;
            uiImage.position = pos_temp;
        }
    }
}