using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public Transform enemy_shot;
	public GameObject bounds_low;
	public float fire_rate;
	private float previous_fire;

	void Update () {
		if (Mathf.Round(Time.time) % 2 == 0 && 
			Time.time > (fire_rate + previous_fire)) {

			Instantiate (enemy_shot, transform.position, Quaternion.identity);
			previous_fire = Time.time;
		}
	}
}
