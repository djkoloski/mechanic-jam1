using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {
	void Awake() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameUI",LoadSceneMode.Additive);
	}

	void Start() {
	}
}
