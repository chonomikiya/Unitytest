using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject = null;
    private RectTransform uiImage;
    private Vector3 offset = new Vector3(0,2,0);
    private  Rigidbody rb;
    public float speed = 0.05f;
    public float moveForceMultiplier;

    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        uiImage = GetComponent<RectTransform>();
    }
 
    void Update()
    {
        // float Reticle_x = Input.GetAxis("Horizontal");
        // float Reticle_y = Input.GetAxis("Vertical");
        // Vector3 movepos = new Vector3(Reticle_x *speed,Reticle_y*speed,0);
        // uiImage.position += movepos;
        // rb.AddForce(Reticle_x*speed,Reticle_y*speed,0);


        uiImage.position
            = RectTransformUtility.
            WorldToScreenPoint(Camera.main,this.offset + targetObject.position);
        }
        // if(uiImage.position.y > 1100){
        //     Vector3 pos = uiImage.position;
        //     pos.y = 1100.0f;
        //     uiImage.position = pos;
        // }
        // if(uiImage.position.y > 1100){
        //     Vector3 pos = uiImage.position;
        //     pos.y = 1100.0f;
        //     uiImage.position = pos;
        // }
    // }
}
    // void Update() {
    //     Vector2 pos;
 
    //     Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
 
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTfm, screenPos, Camera.main, out pos);
 
    //     myRectTfm.position = pos;
 
    // }
