using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour {

	public GameObject Content;

	// Use this for initialization
	void Start () {
//		StartCoroutine (MakeTreasureBox());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MakeTreasureBox() {
		while (true) {
			yield return new WaitForSecondsRealtime (1f);
			GameObject[] treasures = GameObject.FindGameObjectsWithTag ("Treasure");
			foreach (GameObject t in treasures) {
				Destroy (t);
			}

			GameObject treasure = Instantiate(Resources.Load ("Prefabs/treasure")) as GameObject;
			treasure.transform.SetParent(Content.transform);
			treasure.transform.localPosition = new Vector3 (300, 8, 0);
			treasure.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void OnClickTreasureBox() {
		Debug.Log ("aaa");
	}
}
