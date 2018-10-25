using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCollisions : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag.Contains ("Player")) {
			if (target.gameObject.tag == ("PlayerBullet"))
				Destroy (target.gameObject);
			BossProperties.health -= 1;
		}
	}
}
