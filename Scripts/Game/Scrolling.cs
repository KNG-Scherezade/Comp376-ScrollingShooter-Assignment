using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	public float scroll_rate;
	public float scroll_length;

	private Vector3 start_loc;

	void Awake(){
		start_loc = transform.position;
	}

	void Update () {
		if (GameController.boss_mode && scroll_rate != 0) {
			scroll_rate -= 0.01f;
			if (scroll_rate < 0)
				scroll_rate = 0;
		}
		if (this.transform.position.y < scroll_length) {
			this.transform.position = start_loc;
		} else {
			this.transform.position += scroll_rate * Time.deltaTime * Vector3.down;
		}
	}
}
