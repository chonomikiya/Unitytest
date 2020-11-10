using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    enum State {
        chase,bossbattle,broken,gameclear
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
            case State.broken:
                this.transform.LookAt(player.transform);
                pos = transform.position;
                pos.z = player.position.z + offset;
                transform.position = pos;
                break;
            case State.gameclear:
                this.transform.LookAt(player.transform);
                this.transform.Translate(0.1f,0f,0.1f);
                break;
        }
        
    }
    public void isClear(){
        state = State.gameclear;
    }
    public void isBroken(){
        state = State.broken;
    }
    public void camera_state_change(){
        state = State.bossbattle;
    }
}
