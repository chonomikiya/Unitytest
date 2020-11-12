using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆発エフェクトを呼び出す処理20201112
public class BOMBeffectCtl : MonoBehaviour
{
    [SerializeField]
    GameObject simple_detonation = null;
    [SerializeField]
    GameObject tiny_detonation = null;
    [SerializeField]
    GameObject base_detonation = null;
    // Start is called before the first frame update
    // positionと種類を受け取ってその場所で爆発を起こす
    public void Detonation(Vector3 _position,int index){
        GameObject detonator;
        switch(index){
            case 1:
                detonator = Instantiate(simple_detonation,_position,Quaternion.identity) as GameObject;
                break;
            case 2:
                detonator = Instantiate(tiny_detonation,_position,Quaternion.identity) as GameObject;
                break;
            case 3:
                detonator = Instantiate(base_detonation,_position,Quaternion.identity) as GameObject;
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
}
