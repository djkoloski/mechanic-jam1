using UnityEngine;

public class Game : MonoBehaviour
{
	private static Game _instance;
	public static Game Instance
	{
		get { return _instance; }
	}

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
	private void Start()
	{
		SpawnBlocks();
	}

	public void AddScore(int value)
	{
		_score += value;
	}
	public void GetPowerup(Powerup.Type type)
	{
		switch (type)
		{
			case Powerup.Type.BonusScore:
				_score += 100;
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
}