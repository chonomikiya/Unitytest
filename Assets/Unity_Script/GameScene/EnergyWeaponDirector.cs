using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // myCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(chargeTimer){
            this.transform.localPosition = new Vector3(0,0,0);
        }
        if(forceWeapon){
            myRBody.AddRelativeForce(this.transform.forward + releaseWeapon);        
            if(Vector3.Distance
            (this.transform.position,GameObject.Find("Player").transform.position) > 50)
            {
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
        myRBody.velocity = this.transform.forward * 20.0f;
        forceWeapon = true;
        // myRBody.AddRelativeForce(this.transform.forward * releaseWeapon);
    }
}
