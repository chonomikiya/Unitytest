using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftControl : MonoBehaviour
{
    // [SerializeField]
    // GameObject Missile = null;
    Rigidbody m_rigidbody;
    GameObject target = null;
    bool missileWeapon = true;
    [SerializeField]
    GameObject missileprefab = null;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        // Missile = this.transform.Find("PfCruiseMissile").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddRelativeForce(Vector3.forward * 800);
        if((Vector3.Distance(this.transform.position, target.transform.position) < 350 )&& missileWeapon){
            GameObject m_Missile = Instantiate(missileprefab,this.transform.position,this.transform.rotation) as GameObject;
            m_Missile.GetComponent<MissileController>().Fire(m_rigidbody);
            // m_Missile.GetComponent<MissileController>().Fire(GetComponent<Rigidbody>());
            missileWeapon = false;
        }
        if(Vector3.Distance(this.transform.position,target.transform.position) <120){
            m_rigidbody.AddRelativeForce(Vector3.up * 1000);
        }
    }
}
