using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	Master Canvas;
	Transform Physical_Me;
	UnityEngine.UI.Text Me;
	string Chars = "!#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ][^_`abcdefghijklmnopqrstuvwxyz{|}~";

	// Use this for initialization
	void Start () {
		if (this.gameObject.transform.position.y <= -200) {
			Destroy(this.gameObject);
		}
		Canvas = GameObject.Find("Canvas").GetComponent<Master>();
		Physical_Me = this.gameObject.transform;
		Me = this.gameObject.GetComponent<UnityEngine.UI.Text>();
		Me.color = Color.white;
		Me.text = Chars[Random.Range(0, Chars.Length)].ToString();
		StartCoroutine(Life());
	}
		
	IEnumerator Life () {
		yield return new WaitForSeconds(Canvas.Delay);
		Me.color = Color.green;
		GameObject Clone = Instantiate(this.gameObject, new Vector2(Physical_Me.position.x, Physical_Me.position.y), new Quaternion(0, 0, 0, 0), GameObject.Find("Canvas").transform);
		Clone.transform.position = new Vector3(Clone.transform.position.x, Clone.transform.position.y - 40, 0);
		for (int i = 0; i <= 10; i++) {
			yield return new WaitForSeconds(Canvas.Delay);
			Me.color = new Color(0, 1, 0, (255 - (i * 25.5f)) / 255);
		}
		Destroy(this.gameObject);
	}
}
