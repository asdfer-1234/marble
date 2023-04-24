using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	public float maxDistance;
	public float hitOffset;
	
	public float distanceSpeed;
	private float distance;

	private void Start(){
		distance = 0f;
	}
	
	public void Reposition(){
		RaycastHit hit;
		bool hitted = Physics.Raycast(transform.parent.position, -transform.parent.forward, out hit, maxDistance + hitOffset);
		Debug.DrawRay(transform.parent.position, -transform.parent.forward * maxDistance);
		float targetDistance;
		if(hitted){
			targetDistance = hit.distance - hitOffset;
		}
		else{
			targetDistance = maxDistance;
		}
		
		float change = distanceSpeed * Time.deltaTime;

		if(targetDistance > distance){
			distance = Mathf.Min(distance + change, targetDistance);
		}
		else if(targetDistance < distance){
			distance = targetDistance;
		}
		//distance = Mathf.Clamp(distance, 0, maxDistance);

		SetDistance(distance);
	}
	public void SetDistance(float distance){
		transform.localPosition = new Vector3(0, 0, -distance);
	}
}
