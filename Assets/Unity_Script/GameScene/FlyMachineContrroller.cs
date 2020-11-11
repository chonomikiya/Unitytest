using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMachineContrroller : MonoBehaviour
{
    Rigidbody m_rigidbody;
    bool flySwitch = true;
    Vector3 addUpDown = new Vector3 (0,20,0);

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddForce(addUpDown);
        if(this.transform.position.y  > 11 && flySwitch){
            addUpDown.y *= -1;
            flySwitch = !flySwitch;
        }
        if(this.transform.position.y  < 10 && !flySwitch){
            addUpDown.y *= -1;
            flySwitch = !flySwitch;
        }
        
    }
}
