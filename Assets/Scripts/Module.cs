using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
	[SerializeField] KeyCode key;
	public bool triggered => mTriggered;
	private bool mTriggered;
	protected virtual void Update(){
		if(Input.GetKey(key)){
			Hold();
		}
		if(Input.GetKeyDown(key)){
			Down();
		}
		if(Input.GetKeyUp(key)){
			Up();
		}
	}

	protected virtual void Up(){
		mTriggered = false;
	}
	protected virtual void Down(){
		mTriggered = true;
	}
	protected virtual void Hold(){}

}
