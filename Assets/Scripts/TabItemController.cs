using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabItemController : MonoBehaviour {

	public Text GoldRingAmount, GoldRingLevel, MineNecklaceAmount, MineNecklaceLevel;

	void OnEnable() {
		DrawText ();
	}

	void DrawText() {
		GoldRingAmount.text = string.Format("{0:#,###}",GetItemAmount("GoldRing")*DataController.Instance.gameData.GoldBooster).ToString();
		GoldRingLevel.text = "레벨 : " + DataController.Instance.gameData.GoldBooster.ToString();
		MineNecklaceAmount.text = string.Format("{0:#,###}",GetItemAmount("MinerNecklace")*DataController.Instance.gameData.MineBooster).ToString();
		MineNecklaceLevel.text = "레벨 : " + DataController.Instance.gameData.MineBooster.ToString();
	}

	int GetItemAmount(string name) {
		List<Item> ItemList = DataController.Instance.metaData.ItemList;
		int amount = 0;
		foreach (Item Item in ItemList) {
			if (Item.Name.Equals (name)) {
				amount = Item.Amount;
				break;
			}
		}
		return amount;
	}

	public void OnClickGoldBoosterUpgrade() {
		if (DataController.Instance.gameData.Gold >= GetItemAmount("GoldRing")*DataController.Instance.gameData.GoldBooster) {
			DataController.Instance.gameData.Gold -= GetItemAmount("GoldRing")*DataController.Instance.gameData.GoldBooster;
			DataController.Instance.gameData.GoldBooster++;
			DataController.Instance.SaveGameData ();
			DrawText();
		}
	}

	public void OnClickMineBoosterUpgrade() {
		if (DataController.Instance.gameData.Gold >= GetItemAmount("MineNecklace")*DataController.Instance.gameData.MineBooster) {
			DataController.Instance.gameData.Gold -= GetItemAmount("MineNecklace")*DataController.Instance.gameData.MineBooster;
			DataController.Instance.gameData.MineBooster++;
			DataController.Instance.SaveGameData ();
			DrawText();
		}
	}
}
