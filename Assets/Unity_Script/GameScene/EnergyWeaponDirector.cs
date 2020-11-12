using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Playerのエネルギー弾の処理20201112
//見返すとDirectorとGeneraterを二つに分ける必要はなかったのでリファクタリング対象
public class EnergyWeaponDirector : MonoBehaviour
{
    private SphereCollider myCollider;
    private Rigidbody myRBody;
    public bool chargeTimer = false ;
    public Vector3 releaseWeapon = new Vector3(0,0,2000.0f);
    public bool forceWeapon =  false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myRBody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(chargeTimer){
            this.transform.localPosition = new Vector3(0,0,0);
        }
        //Playerの向きの正面に向かって発射
        if(forceWeapon){
            myRBody.AddRelativeForce(this.transform.forward + releaseWeapon);        
            if(Vector3.Distance(this.transform.position,GameObject.Find("Player").transform.position) > 50)
            {
                Destroy(this.gameObject);
                forceWeapon = false;
            }
        }
    }
    public void fireWeapon(){
        myRBody = GetComponentInParent<Rigidbody>();
        chargeTimer = false;
        Vector3 target = GameObject.Find("ReticleTarget").transform.position;
        transform.LookAt(target);
        myRBody.velocity = this.transform.forward * 20.0f;
        forceWeapon = true;
    }
}
