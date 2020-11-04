using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossWeapongenerater : MonoBehaviour
{
    enum State {
    stay,    missile,    gatling
};
    State state;
    GameObject target = null;
    [SerializeField]
    GameObject missilePrefab = null;
    GameObject GatlingRight = null;
    GameObject GatlingLeft = null;
    bool switchAttack = true;
    int acttimer = 0;
    [SerializeField]
    int  threshold = 500;
    // Start is called before the first frame update
    void Start()
    {
        state = State.stay;
        target = GameObject.Find("Player");
        GatlingRight = transform.GetChild(1).gameObject;
        GatlingLeft = transform.GetChild(2).gameObject;
    }
    [SerializeField]
    Vector3 offset = new Vector3(0,0,0);

    // Update is called once per frame
    void Update()
    {
        GatlingLeft.transform.LookAt(target.transform.position);
        GatlingRight.transform.LookAt(target.transform.position);
        switch(state){
            case State.stay:
                if(acttimer > threshold){
                    acttimer = 0;
                    if(switchAttack){
                        state = State.missile;
                        switchAttack = !switchAttack;
                        Debug.Log(this.gameObject.name);
                    }else{
                        state = State.gatling;
                        switchAttack = !switchAttack;
                    }
                }
                break;
            case State.missile:
                    acttimer = 0;
                    // switchAttack = !switchAttack;
                    state = State.stay;
                    missile();
                    Debug.Log("State.missile:");
                break;
            case State.gatling:
                gatling();
                
                break;
        }
        acttimer++;
    }
    private void stay(){
        state = State.missile;        
    }
    private void missile(){
        GameObject missile = Instantiate(missilePrefab,this.transform.position,this.transform.rotation) as GameObject;
        missile.GetComponent<BossMissileControl>().Fire();
    }
    private void gatling(){
        
        GatlingLeft.GetComponent<ParticleSystem>().Play();
        GatlingRight.GetComponent<ParticleSystem>().Play();
        
    }
}
