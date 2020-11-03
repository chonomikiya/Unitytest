using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonMachineController : MonoBehaviour
{
    [SerializeField]
    GameObject target = null;
    GameObject laser = null;
    LineRenderer lineRenderer = null;
    bool Attack = false;
    SphereCollider sphereCollider;

    [SerializeField]
    private float AttackTimer = 200.0f;
    private float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        laser = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        sphereCollider = GetComponentInParent<SphereCollider>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.enabled = false;
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Attack = true;
            lineRenderer.enabled = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            lostTarget();
        }
    }
    private void OnParticleCollision(GameObject other) {
        Debug.Log(this.name);
        if(other.CompareTag("Player")){
            Debug.Log(this.name);
        }
    }
    void lostTarget(){
        Attack = false;
        lineRenderer.enabled = false;
    }
    void isAttack(){
        ParticleSystem muzzleflash;
        muzzleflash = this.GetComponentInChildren<ParticleSystem>();
        muzzleflash.Play();
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.z > this.transform.position.z){
            Attack = false;
            lineRenderer.enabled = false;
        }
        if(Attack){
            lineRenderer.SetPosition(1,new Vector3(0,0,Vector3.Distance(laser.transform.position,target.transform.position)));
            laser.transform.LookAt(target.transform.position);
            Timer++;
            if(AttackTimer/2 < Timer && !lineRenderer.enabled){
               lineRenderer.enabled = true; 
            }
            if(AttackTimer < Timer){
                isAttack();
                Timer = 0.0f;
            }
        }
        Vector3 rotation = target.transform.position;
        rotation.x = -rotation.x;
        this.transform.LookAt(target.transform.position);

    }

}


// public class CannonMachineController : MonoBehaviour
// {
//     [SerializeField]
//     GameObject target = null;
//     LineRenderer lineRenderer = null;
//     bool Attack = false;
//     SphereCollider sphereCollider;

//     [SerializeField]
//     private float AttackTimer = 200.0f;
//     private float Timer = 0.0f;
//     // Start is called before the first frame update
//     void Start()
//     {
//         // target = GameObject.FindWithTag("Player");
//         sphereCollider = GetComponentInParent<SphereCollider>();
//         lineRenderer = GetComponentInChildren<LineRenderer>();
//         lineRenderer.enabled = false;
//     }
//     void OnTriggerEnter(Collider other) {
//         if(other.CompareTag("Player")){
//             Attack = true;
//             lineRenderer.enabled = true;
//         }
//     }
//     void OnTriggerExit(Collider other) {
//         if(other.CompareTag("Player")){
//             lostTarget();
//         }
//     }
//     private void OnParticleCollision(GameObject other) {
//         Debug.Log(this.name);
//         if(other.CompareTag("Player")){
//             Debug.Log(this.name);
//         }
//     }
//     void lostTarget(){
//         Attack = false;
//         lineRenderer.enabled = false;
//     }
//     void isAttack(){
//         ParticleSystem muzzleflash;
//         muzzleflash = this.GetComponentInChildren<ParticleSystem>();
//         muzzleflash.Play();
        
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         if(Camera.main.transform.position.z > this.transform.position.z){
//             Attack = false;
//             lineRenderer.enabled = false;
//         }
//         if(Attack){
//             lineRenderer.SetPosition(1,new Vector3(0,0,Vector3.Distance(GameObject.Find("Light").transform.position,target.transform.position)));
//             GameObject.Find("Laser").transform.LookAt(target.transform.position);
//             Timer++;
//             if(AttackTimer/2 < Timer && !lineRenderer.enabled){
//                lineRenderer.enabled = true; 
//             }
//             if(AttackTimer < Timer){
//                 isAttack();
//                 Timer = 0.0f;
//             }
//         }
//         Vector3 rotation = target.transform.position;
//         rotation.x = -rotation.x;
//         this.transform.LookAt(target.transform.position);

//     }

// }
