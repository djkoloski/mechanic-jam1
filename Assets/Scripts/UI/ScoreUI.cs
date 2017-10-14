using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
	[SerializeField]
	private Text _text;

	private void Update()
	{
		_text.text = Game.Instance.Score.ToString();
	}
}