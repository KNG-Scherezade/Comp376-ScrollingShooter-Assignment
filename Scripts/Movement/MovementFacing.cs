using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFacing : MonoBehaviour {

	public float speed;

	void Update () {
		transform.position = transform.position + transform.up * speed;
	}
}
