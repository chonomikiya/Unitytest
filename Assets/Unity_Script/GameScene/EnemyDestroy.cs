using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    
    int Damage = 0;
    private void OnParticleCollision(GameObject other) {
        Damage++;
        // Destroy(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Damage > 2){
            Destroy(this.gameObject);
            GameObject.FindWithTag("BOMB").GetComponent<BOMBeffectCtl>().Detonation(this.transform.position,2);
        }
    }
}
