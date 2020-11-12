using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Playerのエネルギー弾の生成処理20201112
//見返すとGeneraterとDirectorを二つに分ける必要はなかったのでリファクタリング対象

public class EnergyWeaponGenerater : MonoBehaviour
{
    [SerializeField]
    private GameObject energyWeaponPrefab = null;
    private GameObject energyWeapon = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            energyWeapon = Instantiate(energyWeaponPrefab) as GameObject;
            energyWeapon.GetComponent<EnergyWeaponDirector>().chargeTimer = true;
            energyWeapon.transform.parent = this.transform;
        }
        if(Input.GetKeyUp(KeyCode.X)){
            energyWeapon.GetComponent<EnergyWeaponDirector>().fireWeapon();
        }
    }
}
