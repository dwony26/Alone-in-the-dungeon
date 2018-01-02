using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (SaveGame ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SaveGame() {
		while (true) {
			yield return new WaitForSecondsRealtime (10f);
			DataController.Instance.SaveGameData ();
		}
	}
}
