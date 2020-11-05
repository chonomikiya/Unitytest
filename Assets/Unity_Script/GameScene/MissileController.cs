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
    [SerializeField]
    Vector3 addforce;
    State state;

    
    // Start is called before the first frame update
    void Start()
    {
        state = State.stay;
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        switch(state){
            case State.stay:
                break;
            case State.search:
                this.transform.LookAt(target.transform.position);
                Vector3 velo = m_rigidbody.velocity;
                m_rigidbody.AddForce(Vector3.forward *1000);
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(m_rigidbody.transform.forward);
                }
                if(m_rigidbody.velocity.y > 0){
                    state = State.move;
                    GetComponentInChildren<Collider>().enabled = true;
                    Debug.Log("State.search");
                }
                break;
            case State.move:
                m_rigidbody.AddForce(this.transform.forward * thurust);                
                break;
            case State.delete:
                Destroy(this.gameObject);
                break;
        }

    }
    private IEnumerator statectl(){
        yield return new WaitForSeconds(5);
        state = State.delete;
    }
    public void Fire(Rigidbody parent){
        target = GameObject.Find("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = false;
        m_rigidbody.velocity = parent.velocity;
        state = State.search;
        this.transform.LookAt(target.transform.position);
        // Vector3 temp = m_rigidbody.velocity;
        // temp.y -= 20; 
        // m_rigidbody.velocity = temp;
    }
}
