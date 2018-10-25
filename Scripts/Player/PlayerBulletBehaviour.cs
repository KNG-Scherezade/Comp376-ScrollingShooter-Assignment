using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehaviour : MonoBehaviour {

	public int warp_count = 0;
	private int warp_max = 3;

	public float x_bound;
	public float y_bound;

	void OnTriggerEnter2D(Collider2D target){
		if (target.transform.tag == "BossShield") {
			Destroy (this.gameObject);
		}
	}

	void Update(){
		if (warp_count < warp_max && StateStorage.game_dificulty == 2) {
			if (Mathf.Abs (transform.position.x) > x_bound) {
				transform.position = new Vector3(-transform.position.x, transform.position.y);
				warp_count++;
			}
			else if (Mathf.Abs (transform.position.y) > y_bound) {
				transform.position = new Vector3(transform.position.x, -transform.position.y);
				warp_count++;
			}
		}
	}
}

