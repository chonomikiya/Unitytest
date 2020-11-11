using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCtl : MonoBehaviour
{
    AudioSource bossBGM;
    AudioSource startBGMsource;
    [SerializeField]
    GameObject　startBGM = null;
    bool VolumCtl = false;
    public void bossBGMPlay(){
        bossBGM.Play();        
    }
    public void BGMstop(){
        VolumCtl = true;
    }
    
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
