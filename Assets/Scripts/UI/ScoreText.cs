using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	[SerializeField]
	private Text _text;

	private void Update()
	{
		_text.text = "Score " + Game.Instance.Score.ToString();
	}
}