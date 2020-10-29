using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collider : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        Debug.Log(other.name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
