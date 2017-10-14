using UnityEngine;

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

	private void Awake()
	{
		_instance = this;

		_score = 0;
	}

	public void AddScore(int value)
	{
		_score += value;
	}
}