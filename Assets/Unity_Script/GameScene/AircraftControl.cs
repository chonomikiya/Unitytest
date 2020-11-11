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
    Vector3 m_position;
    [SerializeField]
    GameObject BOMBPrefab = null;
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
        GameObject BOMBeffect = Instantiate(BOMBPrefab,this.transform.position,this.transform.rotation) as GameObject;
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddRelativeForce(Vector3.forward * 500);
        if(this.transform.position.y < 15){
            m_position =this.transform.position;
            m_position.y = 15;
            this.transform.position = m_position;
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
            GameObject BOMBeffect = Instantiate(BOMBPrefab,this.transform.position,this.transform.rotation) as GameObject;
            Destroy(this.gameObject);
        }
        if(this.transform.position.z <Camera.main.transform.position.z -20){
            Destroy(this.gameObject);
        }
    }
}
