using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//カメラの管理20201112
public class CameraController : MonoBehaviour
{
    enum State {
        chase,bossbattle,broken,gameclear,stay
    }
    State state;
    public float offset = -10.0f;
    [SerializeField]
    private Transform player = null;
    float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = State.chase;
    }

    // Update is called once per frame
    
    private void FixedUpdate() {
        
        switch(state){
            //Playerの後ろに張り付いている状態
            case State.chase:
                Vector3 pos = transform.position;
                pos.z = player.position.z + offset;
                transform.position = pos;
                break;
            //bossの高さに合わせる
            case State.bossbattle:
                if(this.transform.position.y < 20){
                    this.transform.Translate(0f,0.01f,0f);
                    player.transform.Translate(0f,0.01f,0f);
                }
                pos = transform.position;
                pos.z = player.position.z + offset;
                transform.position = pos;
                break;
            //Playerが倒された時見下す状態
            case State.broken:
                this.transform.LookAt(player.transform);
                pos = transform.position;
                pos.z = player.position.z + offset;
                transform.position = pos;
                break;
            //bossを倒した時に少し前に移動してPlayerを横から見る処理
            case State.gameclear:
                this.transform.LookAt(player.transform);
                if(count < 100){
                    this.transform.Translate(0.05f,0f,0.05f);
                    count++;
                }else{
                    player.GetComponent<PlayerController>().isGameClear();
                    state = State.stay;
                }
                break;
            //Playerを見送る処理
            case State.stay:
                this.transform.LookAt(player.transform);
                if(Vector3.Distance(this.transform.position,player.transform.position) > 100){
                    GameObject.FindWithTag("SceneManager").GetComponent<GameSceneDirector>().LoadGameClear();

                }
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
