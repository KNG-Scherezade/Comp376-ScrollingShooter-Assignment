using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public float speed;
	public Transform bullet;
	public float bullet_rotation;
	public float fire_rate;
	private float previous_fire_time;
	public Transform death;

	private int power_level = 0;

	private void gameOverSequence(){
		StateStorage.game_over = true;
		power_level = 0;
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.transform.tag == "PowerUp") {
			Destroy (target.gameObject);
			power_level++;
			this.GetComponents<AudioSource> ()[0].Play ();
		} 
		else if (target.transform.tag != "PlayerBullet" ||
			(target.transform.GetComponent<PlayerBulletBehaviour>().warp_count != 0
				&& target.transform.tag == "PlayerBullet")) {
			power_level--;
			Instantiate (death, transform.position, Quaternion.identity);
			if (power_level < 0) {
				if(!target.transform.tag.Contains("Boss"))
					Destroy (target.gameObject);
				Destroy (this.gameObject);
				gameOverSequence ();
			}
		}
	}

	void Update () {
		float ud = Input.GetAxis ("Horizontal");
		float lr = Input.GetAxis("Vertical");


		this.transform.position = new Vector3 (
			Mathf.Clamp(ud * Time.deltaTime * speed + this.transform.position.x , -2.52f, 2.52f),
			Mathf.Clamp(lr * Time.deltaTime * speed + this.transform.position.y, -4.71f, 4.71f),
			this.transform.position.z) ;

		//shoot
		float time = Time.time;
		if (Input.GetKey ("z") && time > (previous_fire_time + fire_rate)) {
			previous_fire_time = Time.time;
			this.GetComponents<AudioSource> ()[1].Play ();
			if (power_level == 0) {
				Instantiate (bullet, this.transform.position, Quaternion.identity);
			} else if (power_level == 1) {
				Instantiate (bullet, new Vector3 (this.transform.position.x - 0.1f, 
					this.transform.position.y), Quaternion.identity);
				Instantiate (bullet, new Vector3 (this.transform.position.x + 0.1f, 
					this.transform.position.y), Quaternion.identity);
			} else {
				Debug.Log (this.transform.rotation);
				Debug.Log (power_level);
				for (int bullet_num = (int)-Mathf.Ceil(power_level/2.0f); bullet_num < power_level; bullet_num++) {
					Instantiate (bullet, this.transform.position, 
						new Quaternion(
							this.transform.eulerAngles.x,
							this.transform.eulerAngles.y,
							(this.transform.eulerAngles.z + bullet_rotation*bullet_num),
							this.transform.rotation.w
						));
					Debug.Log (this.transform.eulerAngles.z + 0.436332 * bullet_num);
				}
			}
		}

	}
}
