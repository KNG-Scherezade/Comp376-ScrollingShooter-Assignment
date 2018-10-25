using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public int difficulty;

	public void Loadscene(int scene_index){
		StateStorage.game_dificulty = difficulty;
		SceneManager.LoadScene(scene_index);
	}

	public void Update(){
		if(Input.GetKeyDown("r")){
			StateStorage.game_dificulty = 0;
			SceneManager.LoadScene(0);
		}
	}
}
