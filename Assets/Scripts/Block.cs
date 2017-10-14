using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField]
	private int _value;
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	public void SetColor(Color color)
	{
		_spriteRenderer.color = color;
	}
	public void OnBallHit()
	{
		Destroy(gameObject);
		Game.Instance.AddScore(_value);
	}
}