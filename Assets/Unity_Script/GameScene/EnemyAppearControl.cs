using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppearControl : MonoBehaviour
{
    [SerializeField]
    GameObject AircraftPrefab = null;
    [SerializeField]
    // GameObject MachinePrefab = null;
    Vector3 distance = new Vector3(0,20,400);
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            EnemyAppear();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyAppear(){
        GameObject Enemy = Instantiate(AircraftPrefab,this.transform.position+distance,this.transform.rotation) as GameObject;
        Enemy.GetComponent<Rigidbody>().velocity = new Vector3(0,10,50);
        Enemy.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,200));
    }
}
