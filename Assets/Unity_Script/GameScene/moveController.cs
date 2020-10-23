using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveController : MonoBehaviour
{
    public float maxSpead; //最大速度
    public float verticalSpead; //縦の旋回速度
    public float horizontalSpead; //横の旋回加速
    public float accel; //加速
    public static float speed = 0; //現在のスピード
    private float minSpeed = 0; //最低速度 マイナスになりすぎないように

    void Start () {
        //最低速度の割り出し（必要に応じて適当に設定）
        minSpeed = maxSpead * (float)0.2 * -1;
    }
    
    void Update () {

        //方向転換
        float v = Input.GetAxis("Vertical") * verticalSpead;
        float h = Input.GetAxis("Horizontal") * horizontalSpead;
        this.transform.Rotate(new Vector3(v, 0, -h));

        //加速処理
        if(maxSpead >= speed)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                //加速
                speed = speed + accel;
            }
        }


        //減速処理
        if (minSpeed <= speed)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = speed - accel;
            }

        }

        //this.transform.Translate(0, 0, speed);
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }
}
