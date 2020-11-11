using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMstopTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject BGMCtl = null;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            BGMCtl.GetComponent<BGMCtl>().BGMstop();
        }
    }

}
