using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchModule : Module
{
	public Vector3 halfExtents;
	public Vector3 force;
	
	protected override void Down(){
		foreach(Collider i in Physics.OverlapBox(transform.position, halfExtents, transform.rotation)){
			Rigidbody rigidbody = i.GetComponent<Rigidbody>();
			if(rigidbody != null){
				rigidbody.AddForce(transform.rotation * force, ForceMode.Impulse);
			}
		}
	}
}
