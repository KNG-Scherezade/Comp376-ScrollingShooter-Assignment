using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text game_over_text;
	public Text win_text;
	public Text score_text;

	public static bool boss_mode;

	public Transform enemy_a_group;
	public Transform enemy_b_group;
	public Transform boss_group;
	public Transform powerup;

	public GameObject boss_hud;

	public float spawn_delay;
	public static int spawn_count = 5;
	private float total_spawned;
	public float wave_delay;
	private float wave_in_progress;
	private float previous_wave;

	private float start_time;

	public int boss_time;



	// Use this for initialization
	void Start () {
		restart ();
	}

	private void restart(){
		game_over_text.enabled = false;
		win_text.enabled = false;
		StateStorage.score = 0;
		StateStorage.game_over = false;
		StateStorage.enemies_killed = 0;
		total_spawned = 0;

		boss_mode = false;
		previous_wave = Time.time + spawn_delay;
		BossProperties.dead = false;

		start_time = Time.time + spawn_delay ;
	}
	
	// Update is called once per frame
	void Update () {
		score_text.text = "Score: " + StateStorage.score.ToString();
		if (StateStorage.game_over && !BossProperties.dead)
			game_over_text.enabled = true;  

		if (Time.time > (boss_time + start_time)) {
			if (!boss_mode) {
				Instantiate (boss_group);
				boss_hud.SetActive (true);
			}
			boss_mode = true;
			if (BossProperties.dead && !StateStorage.game_over) {
				win_text.enabled = true;
			}

		} else if (Time.time > (previous_wave + wave_delay)) {
			if (total_spawned == 0) {
				StateStorage.enemies_killed = 0;
			}
			Debug.Log ("S");
			previous_wave = Time.time;
			int spawn_type = Random.Range (0, 2);
			if (spawn_type == 0) {
				Instantiate (enemy_a_group, 
					enemy_a_group.position, Quaternion.identity);
			} else {
				if (Random.Range (0, 2) == 0) {
					MovementCos.sign = -1;
					Instantiate (enemy_b_group, 
						enemy_b_group.position, Quaternion.identity);
				} else {
					MovementCos.sign = 1;
					Instantiate (enemy_b_group, 
						new Vector3 (-enemy_b_group.position.x, enemy_b_group.position.y), Quaternion.identity);
				}
			}
		}
	}
}
