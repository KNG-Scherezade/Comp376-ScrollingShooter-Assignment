using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHUDScript : MonoBehaviour {

	public Text hp_text;
	public GameObject hp_bar;
	public float max_size;

	void Start () {
		hp_text.enabled = true;
		hp_bar.SetActive(true);
	}

	void Update(){
		if (BossProperties.dead)
			BossProperties.health = 0;
		hp_bar.transform.localScale = new Vector3 (
			max_size - max_size * BossProperties.health / BossProperties.max_hp,
			hp_bar.transform.localScale.y);
	}
}
