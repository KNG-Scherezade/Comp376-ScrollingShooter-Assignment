using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakpoints : MonoBehaviour {

	private int hit_count;
	public Material off;
	public Material on;

	public float time_reactivate;


	void OnTriggerEnter2D(Collider2D target){
		Debug.Log ("hit");
		if (target.gameObject.tag.Contains("Player")) {
			if (target.gameObject.tag == "PlayerBullet")
				Destroy (target.gameObject);
			hit_count++;
			if (hit_count == 2) {
				this.gameObject.GetComponent<MeshRenderer> ().sharedMaterial  = off;
				BossProperties.num_weakpoints_hit++;
				if (BossProperties.num_weakpoints_hit == 2) {
					Debug.Log (BossProperties.time_off + time_reactivate);
					Debug.Log (Time.time);
					BossProperties.time_off = Time.time;
				}
			}
		}
	}

	void Update(){
		
		if (BossProperties.time_off != 0 && Time.time > BossProperties.time_off + time_reactivate) {
			Debug.Log ("Off");
			BossProperties.num_weakpoints_hit--;
			hit_count = 0;
			this.gameObject.GetComponent<Renderer> ().sharedMaterial = on;
			if (BossProperties.num_weakpoints_hit == 0) {
				BossProperties.time_off = 0;
			}
		}
	}
}
