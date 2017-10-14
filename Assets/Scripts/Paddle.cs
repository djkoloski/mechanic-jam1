using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField]
	private float _horizontalMovementSpeed;
	[SerializeField]
	private Vector2 _bounceCenterOffset;

	public Vector2 Size
	{
		get
		{
			return _boxCollider2d.size;
		}
	}
	public Vector2 BounceCenter
	{
		get { return (Vector2)transform.position + _bounceCenterOffset; }
	}

	private BoxCollider2D _boxCollider2d;
	private Rigidbody2D _rigidbody2d;

	private void Awake()
	{
		_boxCollider2d = GetComponent<BoxCollider2D>();
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		_rigidbody2d.velocity = Vector2.right * Input.GetAxis("Horizontal") * _horizontalMovementSpeed;
	}
	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + (Vector3)_bounceCenterOffset);
	}
}