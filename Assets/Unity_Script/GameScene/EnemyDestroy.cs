using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerから攻撃を受けた際の処理20201112
public class EnemyDestroy : MonoBehaviour
{
    
    int Damage = 0;
    private void OnParticleCollision(GameObject other) {
        Damage++;
    }
    // Update is called once per frame
    void Update()
    {
        //ダメージが3以上なら自身を消去して爆発を呼び出す
        if(Damage > 2){
            Destroy(this.gameObject);
            GameObject.FindWithTag("BOMB").GetComponent<BOMBeffectCtl>().Detonation(this.transform.position,2);
        }
    }
}
