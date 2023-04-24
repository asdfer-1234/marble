using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Marble : MonoBehaviour
{
	private new Rigidbody rigidbody;
	private AudioSource audioSource;
	public float rollForce;
	public float volumeMultiplier;
	public float randomPitch;

	void Start(){
		rigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	void FixedUpdate(){
		Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Vector3 force = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0) * 
				new Vector3(movement.x, 0, movement.y)
				.normalized;
		rigidbody.AddForce(force * rollForce * Time.fixedDeltaTime);
	}

	void OnCollisionEnter(Collision collision){
		audioSource.volume = collision.relativeVelocity.magnitude * volumeMultiplier;
		audioSource.pitch = Random.Range(0f, randomPitch);
		audioSource.Play();
	}
}
