using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    GameObject bossEnemy;
    [SerializeField]
    GameObject _HPbarCtl = null;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            bossEnemy.GetComponent<bossWeapongenerater>().Battle();
            Camera.main.GetComponent<CameraController>().camera_state_change();
            _HPbarCtl.GetComponent<HPbarCtl>().BossHPbarappear();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bossEnemy = GameObject.Find("SF_Free-Fighter").gameObject;
    }


}
