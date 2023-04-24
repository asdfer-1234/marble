using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleFollower : MonoBehaviour
{
	public Transform marble;
	private Vector2 look;
	[SerializeField] private Vector2 mouseSensitivity;
	public ThirdPersonCamera thirdPersonCamera;

	void Start(){
		look = Vector2.zero;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void LateUpdate(){
		transform.position = marble.position;
		Vector2 movement = new Vector2(
				Input.GetAxis("Mouse X"),
				-Input.GetAxis("Mouse Y")
				) * Time.deltaTime;
		look = LimitLook(look + movement * mouseSensitivity);
		transform.rotation =
				Quaternion.Euler(look.y, look.x, 0);
		thirdPersonCamera.Reposition();
	}

	private Vector2 LimitLook(Vector2 look){
		look.y = Mathf.Clamp(look.y, -80f, 80f);
		look.x = Mathf.Repeat(look.x, 360f);
		return look;
	}
}
