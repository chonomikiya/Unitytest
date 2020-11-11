using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyControl : MonoBehaviour
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
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        // バネ復元力でゆらゆら揺れ続けるのを防ぐため、angularDragを大きめにしておく
        m_rigidbody.angularDrag = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_rigidbody.angularDrag < 20.0f){
            m_rigidbody.angularDrag += 0.5f;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speedCtl = 19;
        }else {
            speedCtl = 0;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        // xとyにspeedを掛ける
        m_rigidbody.AddForce(x * (speed - speedCtl), y * (speed - speedCtl), 0);

        Vector3 moveVector = Vector3.zero;

        m_rigidbody.AddForce(moveForceMultiplier * (moveVector - m_rigidbody.velocity));
        
        this.m_rigidbody.drag = 2;

        // プレイヤーの入力に応じて姿勢をひねろうとするトルク
        Vector3 rotationTorque = new Vector3(-y * pitchTorqueMagnitude, x * yawTorqueMagnitude, -x * rollTorqueMagnitude);

        // 現在の姿勢のずれに比例した大きさで逆方向にひねろうとするトルク
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 forward = transform.forward;
        Vector3 restoringTorque = new Vector3(forward.y - up.z, right.z - forward.x, up.x - right.y) * restoringTorqueMagnitude;

        // 機体にトルクを加える
        m_rigidbody.AddTorque(rotationTorque + restoringTorque);
    }
}
