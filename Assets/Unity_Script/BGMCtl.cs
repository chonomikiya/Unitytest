using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCtl : MonoBehaviour
{
    AudioSource bossBGM;

    public void bossBGMPlay(){
        bossBGM.Play();        
    }
    
    private void Start() {
        bossBGM = GetComponent<AudioSource>();
    }
}
