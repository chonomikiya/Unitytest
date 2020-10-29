using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_test : MonoBehaviour
{
    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    // void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.CompareTag("Bullet_Fire")){
    //         Debug.Log(other.gameObject.name.ToString());
    //     }
    // }
    // void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("Bullet_Fire")){
    //         Debug.Log(other.gameObject.name.ToString());
    //     }
    // }
    private void OnParticleCollision(GameObject other) {
        Debug.Log("particle");
    }


    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Translate (0, 0, 3);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.Translate (0, 0, -3);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.Translate (-3, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.Translate (3, 0, 0);
		}
        if(Input.GetKeyDown (KeyCode.Z)){
            transform.Translate (0,3,0);
        }
        if(Input.GetKeyDown (KeyCode.X)){
            transform.Translate (0,-3,0);
        }
        this.transform.LookAt(GameObject.Find("CannonMachine").transform);
	}
}
