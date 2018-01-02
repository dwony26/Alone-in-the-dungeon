using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour {

	public GameObject Tab, TabMonster, TabQuest, TabItem, TabShop;

	// Use this for initialization
	void Start () {
		Tab.SetActive (false);
	}

	public void OnClickButtonMonster() {
		if (Tab.activeSelf && TabMonster.activeSelf) {
			Tab.SetActive (false);
		} else {
			Tab.SetActive (true);
			TabMonster.SetActive (true);
			TabQuest.SetActive (false);
			TabItem.SetActive (false);
			TabShop.SetActive (false);
		}
	}

	public void OnClickButtonQuest() {
		if (Tab.activeSelf && TabQuest.activeSelf) {
			Tab.SetActive (false);
		} else {
			Tab.SetActive (true);
			TabMonster.SetActive (false);
			TabQuest.SetActive (true);
			TabItem.SetActive (false);
			TabShop.SetActive (false);
		}
	}

	public void OnClickButtonItem() {
		if (Tab.activeSelf && TabItem.activeSelf) {
			Tab.SetActive (false);
		} else {
			Tab.SetActive (true);
			TabMonster.SetActive (false);
			TabQuest.SetActive (false);
			TabItem.SetActive (true);
			TabShop.SetActive (false);		
		}
	}

	public void OnClickButtonShop() {
		if (Tab.activeSelf && TabShop.activeSelf) {
			Tab.SetActive (false);
		} else {
			Tab.SetActive (true);
			TabMonster.SetActive (false);
			TabQuest.SetActive (false);
			TabItem.SetActive (false);
			TabShop.SetActive (true);
		}
	}

}
