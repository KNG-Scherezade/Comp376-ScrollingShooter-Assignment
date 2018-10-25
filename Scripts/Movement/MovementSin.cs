using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSin : MonoBehaviour {

	public float speed;
	public float radius;

	void Update () {
		transform.position = transform.position + 
			new Vector3 (
				radius * Mathf.Sin(speed * Time.time) * Time.deltaTime, 
				speed * Time.deltaTime, 
				0);
	}
}
