using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    Rigidbody m_rigidbody;
    bool fire = false;
    Vector3 addforce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(fire){
            m_rigidbody.AddForce(addforce);
        }
    }
    public void Fire(){
        m_rigidbody = GetComponentInParent<Rigidbody>();
        m_rigidbody.useGravity = true;
        addforce = m_rigidbody.velocity;
    }
}
