using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    GameObject bossEnemy;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            bossEnemy.GetComponent<bossWeapongenerater>().Battle();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bossEnemy = GameObject.Find("SF_Free-Fighter").gameObject;
    }


}
