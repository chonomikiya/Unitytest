using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BGM関係の管理と処理20201112
public class BGMCtl : MonoBehaviour
{
    AudioSource bossBGM;
    AudioSource startBGMsource;
    [SerializeField]
    GameObject　startBGM = null;
    bool VolumCtl = false;
    //ボス戦時BGMを再生
    public void bossBGMPlay(){
        bossBGM.Play();        
    }
    //道中BGMのフェードアウト演出をtrueにするフラグ
    public void BGMstop(){
        VolumCtl = true;
    }
    //Sceneが始まったら道中BGMを再生
    private void Start() {
        bossBGM = GetComponent<AudioSource>();
        startBGMsource = startBGM.GetComponent<AudioSource>();
        startBGMsource.Play();
    }
    
    private void Update() {
        if(VolumCtl)   {
            startBGMsource.volume -= 0.01f;
            if(startBGMsource.volume < 0){
                VolumCtl =false;
            }
        }
    }
}
