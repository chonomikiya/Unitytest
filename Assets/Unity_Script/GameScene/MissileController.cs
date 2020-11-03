using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    enum State {
        stay,search,move,delete
    };
public class MissileController : MonoBehaviour
{
    GameObject target = null;
    Rigidbody m_rigidbody;
    [SerializeField]
    float thurust = 1000.0f;
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
                this.transform.LookAt(target.transform);
                m_rigidbody.AddForce(this.transform.forward* thurust);
                if(m_rigidbody.velocity.z >150){
                    state = State.move;
                    StartCoroutine(statectl());
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
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = false;
        m_rigidbody.velocity = parent.velocity;
        state = State.search;
        // m_rigidbody.AddForce(this.transform.forward * 2000.0f);
        Debug.Log(parent.velocity);
        this.transform.LookAt(target.transform.position);
    }
}
