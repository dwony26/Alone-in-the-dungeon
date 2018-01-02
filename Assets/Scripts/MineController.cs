using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineController : MonoBehaviour {

	public Text TextRatio;

	// Use this for initialization
	void Start () {
		StartCoroutine (StartMining ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StartMining() {
		while (true) {
			yield return new WaitForSecondsRealtime (0.1f);
			DataController.Instance.gameData.MineDamage += DataController.Instance.metaData.OrcMinerPower * DataController.Instance.gameData.OrcMinerLevel;
			float mineRatio = Mathf.Round((float) DataController.Instance.gameData.MineDamage * DataController.Instance.gameData.MineBooster / (DataController.Instance.metaData.MineHealth * DataController.Instance.gameData.Floor) * 10000) / 100;
			if (mineRatio >= 100) {
				NotificationCenter.Instance.Notify ("AddFloor");
				DataController.Instance.SaveGameData ();
			}
			TextRatio.text = mineRatio.ToString() + "%";
		}
	}
}
