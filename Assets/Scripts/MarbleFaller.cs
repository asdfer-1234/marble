using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleFaller : MonoBehaviour
{
	public float resetHeight;
	private new Rigidbody rigidbody;

	void Start(){
		rigidbody = GetComponent<Rigidbody>();
	}
	void Update(){
		if(transform.position.y < -resetHeight){
			transform.position = new Vector3(0, resetHeight, 0);
			rigidbody.velocity = Vector3.zero;
		}
	}
}
