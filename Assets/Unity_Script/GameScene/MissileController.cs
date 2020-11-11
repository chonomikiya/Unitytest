using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissileController : MonoBehaviour
{
    enum State {
        stay,search,move,delete
    };
    GameObject target = null;
    Rigidbody m_rigidbody;
    [SerializeField]
    float thurust = 500.0f;
    State state;

    private void OnCollisionEnter(Collision other) {
        GameObject.FindWithTag("BOMB").GetComponent<BOMBeffectCtl>()
        .Detonation(this.transform.position,2);
        Destroy(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // // state = State.stay;
        // target = GameObject.Find("Player");
        // m_rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        switch(state){
            case State.stay:
                break;
            case State.search:
                this.transform.LookAt(target.transform);
                // Vector3 velo = m_rigidbody.velocity;
                // velo.y = (-velo.y)+10;
                // velo.z *=-1;
                m_rigidbody.AddRelativeForce(Vector3.forward *thurust);
                if(Vector3.Distance(this.transform.position,target.transform.position ) < 100){
                    Debug.Log(Vector3.Distance(this.transform.position,target.transform.position));

                    state = State.move;
                    Debug.Log("State.search");
                    GetComponent<Collider>().enabled = true;
                }
                break;
            case State.move:
                m_rigidbody.AddRelativeForce(Vector3.forward *thurust);
                if(this.transform.position.z < Camera.main.transform.position.z -20){
                    state = State.delete;
                }
                break;
            case State.delete:
                Destroy(this.gameObject);
                break;
        }

    }
    public void Fire(Rigidbody parent){
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = false;
        state = State.search;
        this.transform.LookAt(target.transform);
        // m_rigidbody.velocity = addforce;

    }
}
