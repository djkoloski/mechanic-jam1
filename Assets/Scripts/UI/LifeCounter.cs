using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LifeCounter : MonoBehaviour {

	[SerializeField]
	GameObject lifePrefab;

	void Update () {
		SetLifeDisplay(Game.Instance.Lives);
	}

	public void SetLifeDisplay(int value) {

		if (value < 0)
			return;
		if (transform.childCount > value) {
				while(transform.childCount != value) {
					GameObject lastLife = transform.GetChild(transform.childCount - 1).gameObject;
					GameObject.DestroyImmediate(lastLife);
				}
		}
		else if (transform.childCount < value) {
			while(transform.childCount != value) {
				GameObject.Instantiate(lifePrefab, transform, false);
			}
		}
	}
}
