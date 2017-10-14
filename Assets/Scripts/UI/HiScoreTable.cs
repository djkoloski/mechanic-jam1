using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScoreTable : MonoBehaviour {

	HiScoreDisplay _hiScore;
	TextMesh _label;

	[SerializeField]
	private GameObject _textPrefab;

	[SerializeField]
	private float ScoreListOffset = 0.0f;
	[SerializeField]
	private float ScoreListSpacing = 0.0f;
	[SerializeField]
	private float numScores;

	void Awake () {
		_label = GetComponent<TextMesh>();
		for (int i = 1; i <= numScores; ++i) {
			GameObject tempObject = Instantiate(_textPrefab, transform);
			tempObject.name = "ScoreListing_" + i.ToString();
			tempObject.transform.localPosition = new Vector3(0.0f,-0.25f * (float)i - ScoreListSpacing * (float)i - ScoreListOffset,-2.0f);
		}
		_hiScore = FindObjectOfType<HiScoreDisplay>();
		_label = GetComponent<TextMesh>();
	}

	public void UpdateScoreText () {
		List<ScoreEntry> currentScoreTable = _hiScore.HiScoreTable;
		Debug.Assert(numScores >= currentScoreTable.Count);
		for (int i = 1; i <= numScores; ++i) {
			GameObject foundChild = transform.Find("ScoreListing_" + i.ToString()).gameObject;
			TextMesh foundText = foundChild.GetComponent<TextMesh>();
			foundText.color = Color.HSVToRGB((float)(currentScoreTable[i-1].ColorHue)/256.0f,1.0f,1.0f);
			foundText.text = currentScoreTable[i-1].Initials + new string(' ', 10 - currentScoreTable[i-1].Score.ToString().Length) + currentScoreTable[i-1].Score.ToString();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
