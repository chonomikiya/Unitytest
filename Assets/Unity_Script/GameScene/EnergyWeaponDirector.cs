using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeaponDirector : MonoBehaviour
{
    private SphereCollider myCollider;
    private Rigidbody myRBody;
    public bool chargeTimer = false ;
    public float releaseWeapon = 2000;
    public bool forceWeapon =  false;
    
    
    // Start is called before the first frame update
    void Start()
    {

        myRBody = GetComponent<Rigidbody>();
        // myCollider = GetComponent<SphereCollider>();
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,40.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(chargeTimer){
            this.transform.localPosition = new Vector3(0,0,0);
        }
        if(forceWeapon){
            myRBody.AddRelativeForce(this.transform.forward * releaseWeapon);
        
            if(this.transform.localPosition.z > 200){
                Destroy(this.gameObject);
                forceWeapon = false;
            }
        }
    }
    public void fireWeapon(){
        // myCollider.enabled = !myCollider.enabled;
        chargeTimer = false;
        // float dis = Vector3.Distance(transform.position,GameObject.Find("ReticleTarget").transform.position);
        
        Vector3 target = GameObject.Find("ReticleTarget").transform.position;
        transform.LookAt(target);
        forceWeapon = true;
        // myRBody.AddRelativeForce(this.transform.forward * releaseWeapon);
    }
}
