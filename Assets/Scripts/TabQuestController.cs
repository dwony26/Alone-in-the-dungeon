using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabQuestController : MonoBehaviour {

	public Text MineQuestAmount, MineQuestCondition;

	void OnEnable() {
		DrawText ();
	}

	void DrawText() {
		MineQuestAmount.text = string.Format ("{0:#,###}", DataController.Instance.gameData.MineQuestLevel * DataController.Instance.QuestDic["MineQuest"].Reward).ToString ();
		MineQuestCondition.text = string.Format ("{0:#,###}", DataController.Instance.gameData.MineQuestLevel * 5).ToString () + "층 이상";
	}

	public void OnClickMineQuest() {
		if (DataController.Instance.gameData.Floor >= DataController.Instance.gameData.MineQuestLevel * 5) {
			DataController.Instance.gameData.Gold += DataController.Instance.gameData.MineQuestLevel * DataController.Instance.QuestDic ["MineQuest"].Reward;
			DataController.Instance.gameData.MineQuestLevel++;
			DataController.Instance.SaveGameData ();
			DrawText ();
		}
	}

}
