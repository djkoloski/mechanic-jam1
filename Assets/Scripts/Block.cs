using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField]
	private int _value;

	public void OnBallHit()
	{
		Destroy(gameObject);
		Game.Instance.AddScore(_value);
	}
}