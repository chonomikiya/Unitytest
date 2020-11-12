using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の出現を管理20201112
public class EnemyAppearControl : MonoBehaviour
{
    [SerializeField]
    GameObject AircraftPrefab = null;
    //当初AircraftとCanonMachineを交互に出す予定だったので供養
    // [SerializeField]
    // GameObject MachinePrefab = null;

    //AirCraftの出現箇所
    [SerializeField]
    Vector3 distance = new Vector3(0,30,400);
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            EnemyAppear();
        }
    }
    //Aircraftの出現処理
    void EnemyAppear(){
        GameObject Enemy = Instantiate(AircraftPrefab,this.transform.position+distance,this.transform.rotation) as GameObject;
        Enemy.GetComponent<Rigidbody>().velocity = new Vector3(0,40,50);
        Enemy.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,200));
    }
}
