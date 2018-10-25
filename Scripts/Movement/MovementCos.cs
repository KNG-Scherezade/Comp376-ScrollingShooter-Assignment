using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCos : MonoBehaviour {

	public float speed;
	public float radius;
	public static int sign;

	private float start_time;

	void Start(){
		start_time = Time.time;
	}

	void Update () {
		transform.position = transform.position + 
			new Vector3 (
				sign * radius * Mathf.Cos(speed * (Time.time - start_time)) * Time.deltaTime, 
				speed * Time.deltaTime, 
				0);
	}
}
