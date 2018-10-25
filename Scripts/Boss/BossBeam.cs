using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeam : MonoBehaviour {

	public float fire_rate;
	public float end_time;
	private float start_time;
	private int beam_frame_counter;
	public int beam_frame_rate;

	public Transform beam;

	void Start(){
		start_time = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > (start_time + end_time)) {
			start_time = Time.time;
		}
		else if (Time.time > (start_time + fire_rate)) {
			beam_frame_counter++;
			if (beam_frame_rate < beam_frame_counter) {
				Instantiate (beam, this.transform.position, Quaternion.identity);
				beam_frame_counter = 0;
			}
		}
	}
}
