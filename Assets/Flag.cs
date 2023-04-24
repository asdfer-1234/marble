using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ParticleSystem))]
public class Flag : MonoBehaviour
{
	new ParticleSystem particleSystem;
	public string destinationScene;
	public float delay;

	void Start(){
		particleSystem = GetComponent<ParticleSystem>();
	}

	void OnTriggerEnter(Collider other){
		particleSystem.Play();
		StartCoroutine(DelayDestinationScene());
	}

	IEnumerator DelayDestinationScene(){
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(destinationScene);
	}
}
