using UnityEngine;
using UnityEngine.SceneManagement;

public class Kickstart : MonoBehaviour {

	// This component will initialize any global game state before continuing.

	void Start () {
		if (Game.Instance)
			GameObject.Destroy(gameObject);
		SceneManager.LoadScene("GameUI",LoadSceneMode.Additive);
		GameObject.Destroy(gameObject);
	}
}
