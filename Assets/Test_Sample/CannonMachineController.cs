using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMachineController : MonoBehaviour
{
    [SerializeField]
    GameObject target = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = target.transform.position;
        this.transform.LookAt(-target.transform.transform.position);
        if(Input.GetKeyDown(KeyCode.Space)){
            ParticleSystem muzzleflash;
            muzzleflash = this.GetComponentInChildren<ParticleSystem>();
            muzzleflash.Play();
        }

        Ray ray = new Ray(GameObject.Find("Light").transform.position, laser.transform.forward);

            // OnRay();

    }
    [SerializeField]
    GameObject laser;
    LineRenderer lineRenderer;
    Vector3 hitPos;
    Vector3 tmpPos;
    float lazerDistance = 10f;
    float lazerStartPointDistance = 0.15f;
    float lineWidth = 0.01f;
    void OnRay()
    {

        float lazerDistance = 10f;
        Vector3 direction = laser.transform.forward * lazerDistance;
        Vector3 pos = laser.transform.position;

        RaycastHit hit;
        Ray ray = new Ray(pos, laser.transform.forward);
        lineRenderer.SetPosition(0,laser.transform.position);

        if (Physics.Raycast(ray, out hit, lazerDistance))
        {
            lineRenderer.SetPosition(1, pos + direction);
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);
    }
}
