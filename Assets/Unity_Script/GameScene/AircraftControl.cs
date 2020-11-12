using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//戦闘機の処理 20201112
public class AircraftControl : MonoBehaviour
{
    Rigidbody m_rigidbody;
    GameObject target = null;
    bool missileWeapon = true;
    [SerializeField]
    GameObject missileprefab = null;
    Vector3 m_position;
    [SerializeField]
    GameObject BOMBPrefab = null;
    // Start is called before the first frame update    
    void Start()
    {
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
    }
    //エフェクトの当たり判定を受け取る処理20201112
    private void OnParticleCollision(GameObject other) {
        GameObject BOMBeffect = Instantiate(BOMBPrefab,this.transform.position,this.transform.rotation) as GameObject;
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //前に進ませる処理20201112
        m_rigidbody.AddRelativeForce(Vector3.forward * 500);
        //yの高さを一定以下にさせないようにする
        if(this.transform.position.y < 15){
            m_position =this.transform.position;
            m_position.y = 15;
            this.transform.position = m_position;
        }
        //Playerとの距離が近くなったらミサイルのinstanceを作る
        if((Vector3.Distance(this.transform.position, target.transform.position) < 350 )&& missileWeapon){
            GameObject m_Missile = Instantiate(missileprefab,this.transform.position,this.transform.rotation) as GameObject;
            m_Missile.GetComponent<MissileController>().Fire(m_rigidbody);
            missileWeapon = false;
        }
        //ある程度近づいたら上昇する
        if(Vector3.Distance(this.transform.position,target.transform.position) <250){
            m_rigidbody.AddRelativeForce(Vector3.up * 1000);
        }
        //見えなくなったら消去
        if(this.transform.position.z <Camera.main.transform.position.z -20){
            Destroy(this.gameObject);
        }
    }
}
