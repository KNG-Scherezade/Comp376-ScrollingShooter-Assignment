using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGroupDeath : GroupDeath {
	// Update is called once per frame
	void Update () {
		Debug.Log (num_destroyed);
		if (num_destroyed == GameController.spawn_count) {
			Destroy (this.gameObject);
			StateStorage.score += 200 * 5;
			Instantiate (power_up, StateStorage.previous_kill, Quaternion.identity);
		}
	}
}
