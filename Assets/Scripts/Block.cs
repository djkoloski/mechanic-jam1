using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField]
	private int _value;

	public void OnBallHit()
	{
		Game.Instance.AddScore(_value);
		Destroy(gameObject);
	}
}