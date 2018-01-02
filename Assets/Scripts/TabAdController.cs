using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class TabAdController : MonoBehaviour {

	public Text AdButtonText;

	void OnEnable() {
		DrawText ();
	}

	int GetAddGold() {
		return (DataController.Instance.metaData.GetMonsterPower () * DataController.Instance.gameData.Floor * DataController.Instance.gameData.GoldBooster) * 300;
	}

	void DrawText() {
		AdButtonText.text = string.Format ("{0:#,###}", GetAddGold()).ToString ();
	}

	public void OnClickWatchAd () {
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result) {
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");

			DataController.Instance.gameData.Gold += GetAddGold();
			NotificationCenter.Instance.Notify ("GoldUpdate");

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
}
