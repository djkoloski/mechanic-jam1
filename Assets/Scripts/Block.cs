using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField]
	private int _value;
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[Header("Powerups")]
	[SerializeField]
	private float _powerupChance;
	[SerializeField]
	private GameObject _powerupPrefab;

	public void SetColor(Color color)
	{
		_spriteRenderer.color = color;
	}
	public void OnBallHit()
	{
		Game.Instance.AddScore(_value);
		Destroy(gameObject);

		if (Random.value < _powerupChance)
		{
			SpawnPowerup();
		}

		Level.Instance.CheckVictory();
	}

	private void SpawnPowerup()
	{
		Instantiate(_powerupPrefab, transform.position, Quaternion.identity);
	}
}