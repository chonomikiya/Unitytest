using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeaponDirector : MonoBehaviour
{
    private SphereCollider myCollider;
    private Rigidbody myRBody;
    public bool chargeTimer = false ;
    public float releaseWeapon = 2000;
    
    
    // Start is called before the first frame update
    void Start()
    {

        myRBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<SphereCollider>();
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,40.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(chargeTimer){
            this.transform.localPosition = new Vector3(0,0,5);
        }else{
            // this.transform.localPosition += new Vector3(0,0,1);
        }
        if(this.transform.localPosition.z > 500){
            Destroy(this.gameObject);
        }
    }
    public void fireWeapon(){
        myCollider.enabled = !myCollider.enabled;
        chargeTimer = false;
        // float dis = Vector3.Distance(transform.position,GameObject.Find("ReticleTarget").transform.position);
        
        Transform target = GameObject.Find("ReticleTarget").transform;
        transform.LookAt(target,Vector3.forward);
        myRBody.AddForce(Vector3.forward * releaseWeapon);
    }
}
