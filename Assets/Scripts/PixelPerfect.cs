using UnityEngine;

public class PixelPerfect : MonoBehaviour
{
	[SerializeField]
	private int _pixelsPerUnit;

	private Camera _camera;

	private void Awake()
	{
		_camera = GetComponent<Camera>();
	}
	private void Update()
	{
		_camera.orthographicSize = _camera.pixelHeight / _pixelsPerUnit * 0.5f;
	}
}