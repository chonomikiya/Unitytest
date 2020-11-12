using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミサイルの挙動の処理20201112
public class BossMissileControl : MonoBehaviour
{
    enum State {
        stay,search,move,delete
    };
    GameObject target = null;
    Rigidbody m_rigidbody;
    [SerializeField]
    float thurust = 1000.0f;
    [SerializeField]
    Vector3 addforce;
    State state;
    //何かに当たった場合その場所に爆発を呼び出して自身を消去
    private void OnCollisionEnter(Collision other) {
        GameObject.FindWithTag("BOMB").GetComponent<BOMBeffectCtl>()
        .Detonation(this.transform.position,2);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    //ミサイルの挙動
    void Update()
    {
        switch(state){
            //初期状態
            case State.stay:
                break;
            //Playerの方向を向きつつ加速している状態
            case State.search:
                this.transform.LookAt(target.transform);
                Vector3 velo = m_rigidbody.velocity;
                    velo.y = (-velo.y);
                    m_rigidbody.AddForce(velo *10);       
                //右が通常処理、左はマシンのスペックによってうまく処理できなかったので追加した処理
                if((this.transform.position.y < 10 )|| (m_rigidbody.velocity.y > -1)){
                    GetComponentInChildren<Collider>().enabled = true;
                    m_rigidbody.velocity /= 10;
                    state = State.move;
                    Debug.Log("State.search");
                }
                break;
            //真っ直ぐ進ませる処理
            case State.move:
                StartCoroutine(statectl());
                m_rigidbody.AddForce(transform.forward * thurust);
                break;
            //ミサイルがPlayerに当たらなかった場合自身を消去
            case State.delete:
                Destroy(this.gameObject);
                break;
        }
    }
    private IEnumerator statectl(){
        yield return new WaitForSeconds(2);
        state = State.delete;
    }
    //インスタンスを起こした際に呼び出している関数
    //いちいち呼び出していたけれどstart()に入れておけば済んだのでリファクタリング対象
    public void Fire(){
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        state = State.search;
        this.transform.LookAt(target.transform.position);
        m_rigidbody.velocity = (Vector3.down * 10);
        m_rigidbody.AddForce(m_rigidbody.velocity);
    }
}
