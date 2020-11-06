using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerController>().Damage();
        }
    }
}
