using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour {
	
	public Text TextGold;

	// Use this for initialization
	void Start () {
		NotificationCenter.Instance.Add ("GoldUpdate", this.GoldUpdate);
		StartCoroutine (StartGoldCounting ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StartGoldCounting() {
		while (true) {
			yield return new WaitForSecondsRealtime (0.1f);
			DataController.Instance.gameData.EnemyDamage += DataController.Instance.metaData.GetMonsterPower();
			if (DataController.Instance.gameData.EnemyDamage >= GetEnemyHealth()) {
				DataController.Instance.gameData.Gold += (DataController.Instance.gameData.EnemyDamage - GetEnemyHealth()) * DataController.Instance.gameData.Floor * DataController.Instance.gameData.GoldBooster;
				DataController.Instance.gameData.EnemyDamage = 0;
			} else {
				DataController.Instance.gameData.Gold += DataController.Instance.metaData.GetMonsterPower() * DataController.Instance.gameData.Floor * DataController.Instance.gameData.GoldBooster;
			}
			NotificationCenter.Instance.Notify ("GoldUpdate");
		}
	}

	int GetEnemyHealth() {
		int Health = 0;
		List<Enemy> EnemyList = DataController.Instance.metaData.EnemyList;
		foreach (Enemy Enemy in EnemyList) {
			if (Enemy.Floor <= DataController.Instance.gameData.Floor) {
				Health += Enemy.Health;
			}
		}
		return Health;
	}

	public void GoldUpdate() {
		TextGold.text = string.Format("{0:#,###}",DataController.Instance.gameData.Gold).ToString ();
		DataController.Instance.SaveGameData ();
	}


}
