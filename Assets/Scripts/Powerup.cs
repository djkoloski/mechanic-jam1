using UnityEngine;

public class Powerup : MonoBehaviour
{
	public enum Type
	{
		BonusScore
	}

	[SerializeField]
	private Type _type;
	[SerializeField]
	private float _fallSpeed;
	[SerializeField]
	private float _killY;

	private Rigidbody2D _rigidbody2d;

	private void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		_rigidbody2d.velocity = Vector2.down * _fallSpeed;

		if (transform.position.y < _killY)
		{
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject other = collision.gameObject;
		if (other.CompareTag("Paddle"))
		{
			Destroy(gameObject);
			Level.Instance.GetPowerup(_type);
		}
	}
}