using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float offset = -10.0f;
    [SerializeField]
    private Transform player = null;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = player.position.z + offset;
        transform.position = pos;
    }
}
