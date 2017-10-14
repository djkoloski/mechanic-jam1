using UnityEngine;

public class PixelPerfect : MonoBehaviour
{
	[SerializeField]
	private int _pixelsPerUnit;
	[SerializeField]
	private Vector2 _boardSize;

	private Camera _camera;

	private void Awake()
	{
		_camera = GetComponent<Camera>();
	}
	private void Update()
	{
		int scale = Mathf.Min(
			Mathf.FloorToInt(_camera.pixelWidth / (_boardSize.x * _pixelsPerUnit)),
			Mathf.FloorToInt(_camera.pixelHeight / (_boardSize.y * _pixelsPerUnit)));
		_camera.orthographicSize = _camera.pixelHeight / _pixelsPerUnit / scale * 0.5f;
	}
}