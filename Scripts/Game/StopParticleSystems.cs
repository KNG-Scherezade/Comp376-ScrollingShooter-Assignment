using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopParticleSystems : MonoBehaviour {

	public float durration;
	private float creation_time;

	void Start(){
		creation_time = Time.time;
	}

	// Use this for initialization
	void Update () {
		if (Time.time > (durration + creation_time)) {
			this.GetComponent<ParticleSystem> ().Stop(false, ParticleSystemStopBehavior.StopEmitting);
		}
	}
}
