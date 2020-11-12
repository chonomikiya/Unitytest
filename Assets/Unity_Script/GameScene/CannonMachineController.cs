using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マシンの行動処理20201112
public class CannonMachineController : MonoBehaviour
{
    [SerializeField]
    GameObject target = null;
    GameObject laser = null;
    LineRenderer lineRenderer = null;
    AudioSource shootSE = null;
    bool Attack = false;
    SphereCollider sphereCollider;

    [SerializeField]
    private float AttackTimer = 200.0f;
    private float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        laser = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        sphereCollider = GetComponentInParent<SphereCollider>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.enabled = false;
        shootSE = GetComponent<AudioSource>();
    }
    //Playerが一定の範囲に入った時攻撃モードに入る
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Attack = true;
            lineRenderer.enabled = true;
        }
    }
    //Playerが一定の範囲から出たときの処理
    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            lostTarget();
        }
    }
    //Playerからの攻撃を受けたときの処理
    private void OnParticleCollision(GameObject other) {
        Debug.Log(this.name);
        if(other.CompareTag("Player")){
            Debug.Log(this.name);
        }
    }
    //targetを見失ったときに呼び出し
    void lostTarget(){
        Attack = false;
        lineRenderer.enabled = false;
    }
    //攻撃モードに入ったときの処理
    void isAttack(){
        ParticleSystem muzzleflash;
        muzzleflash = this.GetComponentInChildren<ParticleSystem>();
        muzzleflash.Play();
        shootSE.Play();
    }
    // Update is called once per frame
    void Update()
    {
        //カメラの後ろに入り画面に映らなくなった時
        if(Camera.main.transform.position.z > this.transform.position.z){
            Attack = false;
            lineRenderer.enabled = false;
        }
        
        if(Attack){
            //頭のレーザーの長さをtargetとの距離で初期化
            lineRenderer.SetPosition(1,new Vector3(0,0,Vector3.Distance(laser.transform.position,target.transform.position)));
            laser.transform.LookAt(target.transform.position);
            Timer++;
            //レーザーの管理
            if(AttackTimer/2 < Timer && !lineRenderer.enabled){
               lineRenderer.enabled = true; 
            }
            //一定時間経ったら攻撃
            if(AttackTimer < Timer){
                isAttack();
                Timer = 0.0f;
            }
        }
        //targetの方向を向く
        Vector3 rotation = target.transform.position;
        rotation.x = -rotation.x;
        this.transform.LookAt(target.transform.position);

    }

}