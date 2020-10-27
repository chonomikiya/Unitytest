using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeaponGenerater : MonoBehaviour
{
    [SerializeField]
    private GameObject energyWeaponPrefab = null;
    // private bool WeaponInterval = false;
    // private float WeaponTimer = 100;
    private GameObject energyWeapon = null;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            // WeaponInterval = true;
            energyWeapon = Instantiate(energyWeaponPrefab) as GameObject;
            energyWeapon.GetComponent<EnergyWeaponDirector>().chargeTimer = true;
            energyWeapon.transform.parent = GameObject.Find("Player").transform;
        }
        if(Input.GetKeyUp(KeyCode.X)){
            // WeaponInterval = false;
            energyWeapon.GetComponent<EnergyWeaponDirector>().fireWeapon();
        }

        // if(WeaponInterval && energyWeapon == null){
        //     energyWeapon.transform.localScale
        // }
    }
    void EnergyWeapon(){

    }
}
