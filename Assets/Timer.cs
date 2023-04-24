using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour{
	public float time = 0f;
	private TextMeshProUGUI text;

	void Start(){
		text = GetComponent<TextMeshProUGUI>();
	}

	void Update(){
		time += Time.deltaTime;
		int hour = (int)(time / 3600);
		int minute = (int)((time - 3600f * hour) / 60);
		
		text.text = $"{hour.ToString("00")}:{minute.ToString("00")}:{(time % 60f).ToString("00.00")}";
	}
}
