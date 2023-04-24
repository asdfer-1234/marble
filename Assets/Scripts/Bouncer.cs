using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
	public float bounceForce;
	void OnCollisionEnter(Collision collision){
		Vector3 bounce = transform.position - collision.gameObject.transform.position;
		Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
		rigidbody.AddForce(bounce * bounceForce, ForceMode.Impulse);
	}
}
