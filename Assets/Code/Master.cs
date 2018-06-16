using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Master : MonoBehaviour {
	public GameObject Character;
	public float Delay = .03f;
	public float Speed = .1f;

	int Quantity;

	void Start () {
		//Get all the characters falling
		Quantity = Mathf.FloorToInt(this.gameObject.GetComponent<Canvas>().pixelRect.width / 18.75f);
		StartCoroutine(Spawn_Level());
	}

	/*void update () {
		for (int i = 0; i < Positions.Length; i++) {
			if (Positions[i] >= 10 && Random.Range(1,10) == 2) {
				Instantiate(Character, new Vector2(18.75f * i, -18.75f), new Quaternion(0, 0, 0, 0), this.gameObject.transform);
			}
		}
	}*/

	IEnumerator Spawn_Level () {
		while (1 > 0) {
			if (Random.Range(1,6) == 3) {
				yield return new WaitForSeconds(Random.Range(0f, 1f));
				Spawn(Random.Range(0, Quantity));
			}
		}
	}

	void Spawn (int i) {
		GameObject Child = Instantiate(Character, new Vector2(18.75f * i, 1261.29f), new Quaternion(0, 0, 0, 0), this.gameObject.transform);
		Child.transform.position = new Vector2(((this.gameObject.GetComponent<Canvas>().pixelRect.width / Quantity) + (18.75f / 2)) * i, 1261.29f);
	}
}
