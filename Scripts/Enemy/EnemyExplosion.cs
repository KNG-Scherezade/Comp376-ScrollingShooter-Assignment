using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour {

	public Transform death;
	private bool record_death;
	private int score_increment;

	void OnTriggerEnter2D(Collider2D target){
		if (target.transform.tag.Contains ("Player")) {
			Destroy (target.gameObject);
			Destroy (this.gameObject);
			record_death = true;
		}
	}

	void OnDestroy(){
		if (record_death) {
			Debug.Log ("Kill" + this.transform.tag);
			Instantiate (death, transform.position, Quaternion.identity);
			StateStorage.enemies_killed++;
			StateStorage.previous_kill = this.transform.position;
			this.transform.parent.gameObject.GetComponent<GroupDeath> ().num_destroyed++;
			if (this.transform.tag == "EnemyA")
				StateStorage.score  += 100;
			else if (this.transform.tag == "EnemyB")
				StateStorage.score  += 200;
		}
	}
}
