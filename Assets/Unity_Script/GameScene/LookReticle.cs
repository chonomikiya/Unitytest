using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookReticle : MonoBehaviour
{
    GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("ReticleTarget");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);
    }
}
