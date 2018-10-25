using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVerticle : MonoBehaviour {

	public float speed;

	void Update () {
		transform.position = transform.position + new Vector3 (0, speed * 1.0f * Time.deltaTime, 0);
	}
}
