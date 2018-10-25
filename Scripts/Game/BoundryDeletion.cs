using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryDeletion : MonoBehaviour {

	void  OnTriggerExit2D(Collider2D game_object_colider){
		Destroy (game_object_colider.gameObject);
	}

	void  OnTriggerStay2D(Collider2D game_object_colider){
	}

	void  OnTriggerEnter2D(Collider2D game_object_colider){
	}
}
