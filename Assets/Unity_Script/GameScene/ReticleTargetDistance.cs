using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleTargetDistance : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    private float offset = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Reticlepos = player.position;
        Reticlepos.z += offset; 
        // this.transform.position = Reticlepos;
        this.transform.localPosition = new Vector3(0,0,20);
    }
}
