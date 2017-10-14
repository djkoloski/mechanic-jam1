using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	private static Game _instance;
	public static Game Instance
	{
		get { return _instance; }
	}

	private int _score;
	public int Score
	{
		get { return _score; }
	}

	private int _lives;
	public int Lives
	{
		get { return _lives; }
	}

	private int _highscore;
	public int HighScore
	{
		get { return _highscore; }
	}

	private void Start() {
		if (Game.Instance)
			GameObject.Destroy(gameObject);
		else _instance = this;

		DontDestroyOnLoad(gameObject);

		_score = 0;
		if (!PlayerPrefs.HasKey("IsInitialized")) {
			PlayerPrefs.SetInt("IsInitialized",1);
			PlayerPrefs.SetInt("HighScore",1000);
		}
		_highscore = PlayerPrefs.GetInt("HighScore");
		_lives = 3;

		LoadLevel(0);
	}

	public void ReloadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadLevel(int index) {
		SceneManager.LoadScene("Level" + index.ToString("D2"));
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void AddScore(int value)
	{
		_score += value;
	}

	public void RemoveScore(int value)
	{
		_score -= value;
	}

	public void SetHighScore()
	{
		if (_score > _highscore) {
			_highscore = _score;
			PlayerPrefs.SetInt("HighScore",_highscore);
		}
	}

	public void AddLives(int value)
	{
		_lives += value;
	}

	public void RemoveLives(int value)
	{
		_lives -= value;
	}

	public void ResetGame() {
		_score = 0;
		_lives = 3;
		SceneManager.LoadScene("Title");
	}
}