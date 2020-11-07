using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // speedを制御する
    public float movespeed = 10.0f;
    private const float speed = 20;
    public float speedCtl = 0;
    public float moveForceMultiplier;

    // 水平移動時に機首を左右に向けるトルク30.0f
    public float yawTorqueMagnitude = 60.0f;

    // 垂直移動時に機首を上下に向けるトルク60.0f
    public float pitchTorqueMagnitude = 40.0f;

    // 水平移動時に機体を左右に傾けるトルク10.0f
    public float rollTorqueMagnitude = 30.0f;

    // バネのように姿勢を元に戻すトルク100.0f
    public float restoringTorqueMagnitude = 50.0f;

    private Vector3 Player_pos;
    private new Rigidbody rigidbody;
    public bool rb_freezepos_left = false;
    public bool rb_freezepos_right = false;
    public bool rb_freezepos_top = false;
    public bool rb_freezepos_bottom = false;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "camera_limit_left" ){
            rb_freezepos_left = true;
        }
        if(other.gameObject.tag == "camera_limit_right" ){
            rb_freezepos_right = true;
        }
        if(other.gameObject.tag == "camera_limit_top" ){
            rb_freezepos_top = true;
        }
        if(other.gameObject.tag == "camera_limit_bottom" ){
            rb_freezepos_bottom = true;
        }
        if(other.gameObject.CompareTag("BossBattle")){
            movespeed = 0.0f;
        }
    }

    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        // バネ復元力でゆらゆら揺れ続けるのを防ぐため、angularDragを大きめにしておく
        rigidbody.angularDrag = 20.0f;
    }

    void FixedUpdate()
    {
        if(rigidbody.angularDrag < 20.0f){
            rigidbody.angularDrag += 0.5f;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speedCtl = 19;
        }else {
            speedCtl = 0;
        }
        NotOffScreen();
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        // xとyにspeedを掛ける
        rigidbody.AddForce(x * (speed - speedCtl), y * (speed - speedCtl), movespeed);

        Vector3 moveVector = Vector3.zero;

        rigidbody.AddForce(moveForceMultiplier * (moveVector - rigidbody.velocity));
        
        this.rigidbody.drag = 2;

        // プレイヤーの入力に応じて姿勢をひねろうとするトルク
        Vector3 rotationTorque = new Vector3(-y * pitchTorqueMagnitude, x * yawTorqueMagnitude, -x * rollTorqueMagnitude);

        // 現在の姿勢のずれに比例した大きさで逆方向にひねろうとするトルク
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 forward = transform.forward;
        Vector3 restoringTorque = new Vector3(forward.y - up.z, right.z - forward.x, up.x - right.y) * restoringTorqueMagnitude;

        // 機体にトルクを加える
        rigidbody.AddTorque(rotationTorque + restoringTorque);
    }

    void NotOffScreen(){
        if(rb_freezepos_top || rb_freezepos_bottom){
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            if((rb_freezepos_top && Input.GetKey("down") && !Input.GetKey("up")) 
            || (rb_freezepos_bottom && Input.GetKey("up") && !Input.GetKey("down"))){
                if(rb_freezepos_top)rb_freezepos_top =false;
                if(rb_freezepos_bottom)rb_freezepos_bottom = false;
                rigidbody.constraints = RigidbodyConstraints.None;
            }
        }
        if(rb_freezepos_left || rb_freezepos_right){
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            if((rb_freezepos_left && Input.GetKey("right") && !Input.GetKey("left")) 
            ||(rb_freezepos_right && Input.GetKey("left")&&!Input.GetKey("right"))){
                if(rb_freezepos_left)rb_freezepos_left = false;
                if(rb_freezepos_right)rb_freezepos_right = false;
                rigidbody.constraints = RigidbodyConstraints.None;
            }
        }
        if((rb_freezepos_top || rb_freezepos_bottom) 
        && (rb_freezepos_left || rb_freezepos_right)){
            rigidbody.constraints = 
            RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY;
        }
    }
    public void Damage(){
        rigidbody.angularDrag /= 2;
    }
}
