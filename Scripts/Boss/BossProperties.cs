using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProperties : MonoBehaviour {

	public static int num_weakpoints_hit;
	public static float time_off;

	public static bool dead;

	public static int health;
	public static int max_hp;
	public int health_set;

	public GameObject BossShield;
	public GameObject BossCore;
	public GameObject Death;

	void Start(){
		max_hp = health_set;
		health = max_hp;
		dead = false;
		num_weakpoints_hit = 0;
	}

	void Update(){
		if (health <= 0) {
			health = 0;
			Destroy (this.gameObject, 2);
			dead = true;
			Instantiate (Death, this.transform.position, Quaternion.identity);
			StateStorage.score += 100;
		}
		else if (num_weakpoints_hit == 2) {
			BossShield.SetActive (false);
			BossCore.SetActive (true);
		} else {
			BossShield.SetActive (true);
			BossCore.SetActive (false);
		}
	}
}
