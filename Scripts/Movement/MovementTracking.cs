using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracking : MonoBehaviour {

	public float speed;
	private Vector3 track_dir;


	void Start () {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			track_dir = (GameObject.FindGameObjectWithTag ("Player").gameObject.transform.position
			- this.transform.position);
			track_dir.z = 0;
			track_dir = track_dir.normalized;
		} else
			track_dir = new Vector3 (0, -1, 0);
	}
	

	void Update () {
		transform.position = transform.position + track_dir * speed * Time.deltaTime;
	}
}
