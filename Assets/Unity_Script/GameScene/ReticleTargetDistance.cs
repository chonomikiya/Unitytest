using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Reticleを表示する箇所を決める20201112

public class ReticleTargetDistance : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0,-2,20);
    }
}
