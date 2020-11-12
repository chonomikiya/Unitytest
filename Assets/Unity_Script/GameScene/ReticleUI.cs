using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Reticleを表示する処理20201112
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
        rbody = GetComponent<Rigidbody>();
        uiImage = GetComponent<RectTransform>();
    }
 
    void Update()
    {
        uiImage.position
            = RectTransformUtility.
            WorldToScreenPoint(Camera.main,targetObject.position);
        //テストプレイ時Reticleが下の画面外へ出ていたので追加
        if(uiImage.position.y <  10.0f ){
            Vector3 pos_temp = uiImage.position;
            pos_temp.y = 10.0f;
            uiImage.position = pos_temp;
        }
    }
}