using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeaponGenerater : MonoBehaviour
{
    [SerializeField]
    private GameObject energyWeaponPrefab = null;
    private bool WeaponInterval = false;
    // private float WeaponTimer = 100;
    private GameObject energyWeapon = null;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X)&&energyWeapon == null){
            WeaponInterval = true;
        }
        if(WeaponInterval && energyWeapon == null){
            energyWeapon = Instantiate(energyWeaponPrefab) as GameObject;
            energyWeapon.transform.parent = transform;
            WeaponInterval = false;
        }
    }
    void EnergyWeapon(){

    }
}
