using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonMachineの弾が当たった場合の処理20201112
public class BulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerController>().Damage();
        }
    }
}
