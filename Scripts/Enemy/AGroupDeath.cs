using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGroupDeath : GroupDeath {
	// Update is called once per frame
	void Update () {
		if (num_destroyed == GameController.spawn_count) {
			Destroy (this.gameObject);
			StateStorage.score += 100 * 5;
			Instantiate (power_up, StateStorage.previous_kill, Quaternion.identity);
		}
	}
}
