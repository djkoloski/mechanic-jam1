using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	private static Level _instance;
	public static Level Instance
	{
		get { return _instance; }
	}

	[Header("References")]
	[SerializeField]
	private Paddle _paddle;
	[SerializeField]
	private Ball _ball;
	[SerializeField]
	private Transform _powerupRoot;

	[Header("Blocks")]
	[SerializeField]
	private int _blocksWidth;
	[SerializeField]
	private int _blocksHeight;
	[SerializeField]
	private Transform _blocksRoot;
	[SerializeField]
	private GameObject _blockPrefab;
	[SerializeField]
	private float _blockSaturation;
	[SerializeField]
	private float _blockValue;

	// Use this for initialization
	void Start () {

		SpawnBlocks();
	}

	void Awake () {
		_instance = this;
	}

	public void GetPowerup(Powerup.Type type)
	{
		switch (type)
		{
			case Powerup.Type.BonusScore:
				Game.Instance.AddScore(100);
				break;
			default:
				throw new System.InvalidOperationException();
		}
	}

	private void SpawnBlocks()
	{
		for (int y = 0; y < _blocksHeight; ++y)
		{
			for (int x = 0; x < _blocksWidth; ++x)
			{
				GameObject blockGO = Instantiate(_blockPrefab, _blocksRoot);
				blockGO.transform.localPosition =
					new Vector3(
						(x - (_blocksWidth - 1) / 2.0f),
						(y - (_blocksHeight - 1) / 2.0f) * 0.5f,
						0.0f);

				blockGO.GetComponent<Block>().SetColor(Color.HSVToRGB((float)y / _blocksHeight, _blockSaturation, _blockValue));
			}
		}
	}

	public void ResetPlayer() {
		_paddle.Reset();
		_ball.Reset();

	}

	public void CheckVictory() {
		if (_blocksRoot.transform.childCount == 0) {
			Game.Instance.AddScore(1000);
			Game.Instance.ReloadLevel();
		}
	}
}
