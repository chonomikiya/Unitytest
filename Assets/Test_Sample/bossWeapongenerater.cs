using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossWeapongenerater : MonoBehaviour
{
    enum State {
    stay,missile,gatling,longDistance,broken
    }
    State state;
    GameObject target = null;
    [SerializeField]
    GameObject missilePrefab = null;
    GameObject GatlingRight = null;
    GameObject GatlingLeft = null;
    [SerializeField]
    GameObject BossHpSlider = null;
    ParticleSystem m_particleRight = null;
    ParticleSystem m_particleLeft = null;
    bool switchAttack = false;
    int acttimer = 0;
    [SerializeField]
    int  threshold = 500;
    public float bossHP = 100;
    Rigidbody m_rigidbody = null;
    // Start is called before the first frame update
    void Start()
    {
        state = State.longDistance;
        target = GameObject.Find("Player");
        GatlingRight = transform.GetChild(1).gameObject;
        m_particleRight = GatlingRight.GetComponentInChildren<ParticleSystem>();
        GatlingLeft = transform.GetChild(2).gameObject;
        m_particleLeft = GatlingLeft.GetComponentInChildren<ParticleSystem>();
        m_rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other) {
        if((other.gameObject.CompareTag("Terrain")) && (state == State.broken)){
            GameObject.FindWithTag("BOMB").GetComponent<BOMBeffectCtl>().Detonation(this.transform.position,3);
            GameObject.FindWithTag("SceneManager").GetComponent<GameSceneDirector>().BossDefeat();
            Destroy(this.gameObject);

        }
    }
    
    void OnParticleCollision(GameObject other) {
        bossHP--;
        BossHpSlider.GetComponent<HPbarCtl>().BossHPPull();
        Debug.Log(bossHP);
        if(bossHP <0){
            state = State.broken;
        }

    }
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
                        m_particleRight.Play();
                        m_particleLeft.Play();
                    }
                }
                break;
            case State.missile:
                    acttimer = 0;
                    state = State.stay;
                    missile();
                    Debug.Log("State.missile:");
                break;
            case State.gatling:
                if(acttimer > threshold){
                    m_particleRight.Stop();
                    m_particleLeft.Stop();
                    acttimer = 0;
                    state = State.stay;
                }
                break;
            case State.longDistance:
                break;
            case State.broken:
                m_rigidbody.useGravity = true;
                m_rigidbody.AddForce(0,-20,0);
                m_rigidbody.AddTorque(2,20,0);
                break;
        }
        acttimer++;
    }
    public void Battle(){
        state = State.stay;
    }
    private void stay(){
        state = State.missile;        
    }
    private void missile(){
        GameObject missile = Instantiate(missilePrefab,this.transform.position - new Vector3(0,0,5),this.transform.rotation) as GameObject;
        missile.GetComponent<BossMissileControl>().Fire();
    }
    private void gatling(){
        
        GatlingLeft.GetComponentInChildren<ParticleSystem>().Play();
        GatlingRight.GetComponentInChildren<ParticleSystem>().Play();
    }
}
