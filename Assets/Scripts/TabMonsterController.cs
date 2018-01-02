using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMonsterController : MonoBehaviour {

	public Text OrcMinerLevel, OrcMinerUpgradeGold, OrcWarriorLevel, OrcWarriorUpgradeGold;

	void OnEnable() {
		DrawText ();
	}

	void DrawText() {
		OrcMinerLevel.text = "레벨 : " + DataController.Instance.gameData.OrcMinerLevel.ToString ();
		OrcMinerUpgradeGold.text = string.Format ("{0:#,###}", GetUpgradeGold (DataController.Instance.gameData.OrcMinerLevel)).ToString ();
		OrcWarriorLevel.text = "레벨 : " + DataController.Instance.gameData.OrcWarriorLevel.ToString ();
		OrcWarriorUpgradeGold.text = string.Format ("{0:#,###}", GetUpgradeGold (DataController.Instance.gameData.OrcWarriorLevel)).ToString ();
	}

	int GetUpgradeGold(int level) {
		int result = 0;
		for (int i = 1; i <= level; i++) {
			result += i;
			
		}
		return result * DataController.Instance.metaData.UpgradeGold;
	}

	public void OnClickOrcMinerUpgrade() {
		if (DataController.Instance.gameData.Gold >= GetUpgradeGold (DataController.Instance.gameData.OrcMinerLevel)) {
			DataController.Instance.gameData.Gold -= GetUpgradeGold (DataController.Instance.gameData.OrcMinerLevel);
			DataController.Instance.gameData.OrcMinerLevel++;
			DataController.Instance.SaveGameData ();
			DrawText();
		}
	}

	public void OnClickOrcWarriorUpgrade() {
		if (DataController.Instance.gameData.Gold >= GetUpgradeGold (DataController.Instance.gameData.OrcWarriorLevel)) {
			DataController.Instance.gameData.Gold -= GetUpgradeGold (DataController.Instance.gameData.OrcWarriorLevel);
			DataController.Instance.gameData.OrcWarriorLevel++;
			DataController.Instance.SaveGameData ();
			DrawText();
		}
	}
}
