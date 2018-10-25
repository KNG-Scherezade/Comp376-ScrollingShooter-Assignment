using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovePattern : MonoBehaviour {

	public float speed;
	public float stop_y;

	void Update () {
		if (transform.position.y > stop_y)
			transform.position = transform.position + new Vector3 (0, speed * 1.0f * Time.deltaTime, 0);
	}
}
