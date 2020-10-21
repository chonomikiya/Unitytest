using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class TransformScreenToWorld : MonoBehaviour {

	public Transform target; // 追跡させるオブジェクト
	public Transform center; // targetとカメラの距離を設定する用のオブジェクト

	void Update () 
	{
		if( target == null )
			return;
	
		var pos = Vector3.forward * Vector3.Distance(transform.position, center.position);
		target.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + pos);
	}
}