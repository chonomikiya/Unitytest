using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    enum State {
        chase,bossbattle
    }
    State state;
    public float offset = -10.0f;
    [SerializeField]
    private Transform player = null;

    // Start is called before the first frame update
    void Start()
    {
        state = State.chase;

    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case State.chase:
                Vector3 pos = transform.position;
                pos.z = player.position.z + offset;
                transform.position = pos;
                break;
            case State.bossbattle:
                    if(this.transform.position.y < 20){
                        this.transform.Translate(0f,0.1f,0f);
                        player.transform.Translate(0f,0.1f,0f);
                    }
                pos = transform.position;
                pos.z = player.position.z + offset;
                transform.position = pos;
                break;
        }
        
    }
    public void camera_state_change(){
        state = State.bossbattle;
    }
}
