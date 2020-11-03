using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        Debug.Log(other.name);
        other.GetComponent<PlayerController>().Damage();
    }
}
