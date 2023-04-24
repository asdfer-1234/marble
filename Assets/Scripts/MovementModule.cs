using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : Module
{
	private Vector3 startLocation;
	private Vector3 endLocation;
	public Vector3 movement;
	private float progress = 0f;
	public float duration;

	void Start(){
		startLocation = transform.localPosition;
		endLocation = transform.localPosition + movement;
	}

	void FixedUpdate(){
		float progressChange = Time.fixedDeltaTime / duration;
		if(triggered){
			progress += progressChange;
			progress = Mathf.Min(progress, 1f);
		}
		else{
			progress -= progressChange;
			progress = Mathf.Max(progress, 0f);
		}
		transform.localPosition = Vector3.LerpUnclamped(startLocation, endLocation, progress);
	}
}

