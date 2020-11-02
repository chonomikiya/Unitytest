using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftControl : MonoBehaviour
{
    [SerializeField]
    GameObject Missile = null;
    // Start is called before the first frame update
    void Start()
    {
        Missile = this.transform.Find("PfCruiseMissile").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Missile.GetComponent<MissileController>().Fire();
            Missile.transform.parent = null;

        }
    }
}
