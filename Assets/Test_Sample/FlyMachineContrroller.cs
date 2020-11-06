using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMachineContrroller : MonoBehaviour
{
    Rigidbody m_rigidbody;
    bool flySwitch;
    Vector3 addUpDown = new Vector3 (0,5,0);

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddForce(addUpDown);
        if(m_rigidbody.velocity.y  > 1){
            addUpDown.y *= -1;

        }else if(m_rigidbody.velocity.y  < -1){
            addUpDown.y *= -1;

        }
        
    }
}
