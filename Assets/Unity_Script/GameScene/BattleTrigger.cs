using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボス戦フラグ管理用20201112
//フラグ管理のscriptが多いのでリファクタリング対象
public class BattleTrigger : MonoBehaviour
{
    GameObject bossEnemy;
    [SerializeField]
    GameObject _HPbarCtl = null;
    [SerializeField]
    GameObject BGMCtl = null;
    //それぞれのステータスを変更、BGMを再生
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            bossEnemy.GetComponent<bossWeapongenerater>().Battle();
            Camera.main.GetComponent<CameraController>().camera_state_change();
            _HPbarCtl.GetComponent<HPbarCtl>().BossHPbarappear();
            BGMCtl.GetComponent<BGMCtl>().bossBGMPlay();
        }
        if(other.gameObject.CompareTag("Player") && this.CompareTag("stageBGM")){
            BGMCtl.GetComponent<BGMCtl>().BGMstop();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        bossEnemy = GameObject.Find("SF_Free-Fighter").gameObject;
    }
}
