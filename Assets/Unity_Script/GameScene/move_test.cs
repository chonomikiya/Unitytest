using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//test、確認用
public class move_test : MonoBehaviour
{
    GameObject boss;
    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        boss = GameObject.Find("SF_Free-Fighter");
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("particle");
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (0, 0, 0.2f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (0, 0, -0.2f);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-0.2f, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (0.2f, 0, 0);
		}
        if(Input.GetKey (KeyCode.Z)){
            transform.Translate (0,3,0);
        }
        if(Input.GetKey (KeyCode.X)){
            transform.Translate (0,-3,0);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            boss.GetComponent<bossWeapongenerater>().Battle();
        }
	}
}
