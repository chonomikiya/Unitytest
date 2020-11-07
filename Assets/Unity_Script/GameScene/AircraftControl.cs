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
    int Damage = 0;
    [SerializeField]
    GameObject missileprefab = null;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        // Missile = this.transform.Find("PfCruiseMissile").gameObject;
    }
    private void OnCollisionEnter(Collision other) {
        Damage++;
                    Destroy(this.gameObject);

    }
    private void OnParticleCollision(GameObject other) {
                    Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddRelativeForce(Vector3.forward * 500);
        if(this.transform.position.y < 10){
            m_rigidbody.AddRelativeForce(Vector3.up *100);

        }
        if((Vector3.Distance(this.transform.position, target.transform.position) < 350 )&& missileWeapon){
            GameObject m_Missile = Instantiate(missileprefab,this.transform.position,this.transform.rotation) as GameObject;
            m_Missile.GetComponent<MissileController>().Fire(m_rigidbody);
            missileWeapon = false;
        }
        if(Vector3.Distance(this.transform.position,target.transform.position) <250){
            m_rigidbody.AddRelativeForce(Vector3.up * 1000);
        }
        if(Damage> 1){
            Destroy(this.gameObject);
        }
    }
}
