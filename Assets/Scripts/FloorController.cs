using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorController : MonoBehaviour {

	public Transform Content;
	public Text TextFloor;

	// Use this for initialization
	void Start () {
		NotificationCenter.Instance.Add ("AddFloor", this.AddFloor);
		DrawFloor ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DrawFloor() {
		for(int i = 1 ; i <= DataController.Instance.gameData.Floor ; i++) {
			MakeOpenFloor (i);
		}

		MakeMiningFloor ();
		MakeHiddenFloor ();
	}

	void AddFloor() {
		DataController.Instance.gameData.Floor++;
		DataController.Instance.gameData.MineDamage = 0;

		GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
		foreach (GameObject floor in floors) {
			GameObject.Destroy (floor);
		}

		MakeOpenFloor (DataController.Instance.gameData.Floor);
		MakeMiningFloor ();
		MakeHiddenFloor ();
	}

	void MakeOpenFloor(int no) {
		GameObject floor = Instantiate(Resources.Load ("Prefabs/open_floor")) as GameObject;
		floor.transform.SetParent(Content.transform);
		floor.transform.localPosition = new Vector3 (0, 0, 0);
		floor.transform.localScale = new Vector3 (1, 1, 1);
		floor.GetComponentInChildren<Text> ().text = no + "F";
		MakeEnemyObject(floor);
		MakeMonsterObject(floor);
		TextFloor.text = string.Format("{0:#,###}",DataController.Instance.gameData.Floor).ToString() + "F";
	}

	void MakeMiningFloor() {
		GameObject floor = Instantiate(Resources.Load ("Prefabs/mining_floor")) as GameObject;
		floor.transform.SetParent(Content.transform);
		floor.transform.localPosition = new Vector3 (0, 0, 0);
		floor.transform.localScale = new Vector3 (1, 1, 1);
	}

	void MakeHiddenFloor() {
		GameObject floor = Instantiate(Resources.Load ("Prefabs/hidden_floor")) as GameObject;
		floor.transform.SetParent(Content.transform);
		floor.transform.localPosition = new Vector3 (0, 0, 0);
		floor.transform.localScale = new Vector3 (1, 1, 1);
	}

	GameObject MakeGameObject(GameObject go, Transform parent) {
		go.transform.SetParent (parent);
		go.transform.localPosition = new Vector3 (0, 0, 0);
		go.transform.localScale = new Vector3 (1, 1, 1);
		return go;
	}

	void MakeEnemyObject(GameObject go) {
		List<Enemy> EnemyList = DataController.Instance.metaData.EnemyList;
		foreach (Enemy Enemy in EnemyList) {
			if (Enemy.Floor <= DataController.Instance.gameData.Floor) {
				GameObject prefab = Instantiate (Resources.Load ("Prefabs/" + Enemy.Name)) as GameObject;
				MakeGameObject (prefab, go.transform);
			}
		}
	}

	void MakeMonsterObject(GameObject go) {
		List<Monster> MonsterList = DataController.Instance.metaData.MonsterList;
		foreach (Monster Monster in MonsterList) {
			if (Monster.Floor <= DataController.Instance.gameData.Floor) {
				GameObject prefab = Instantiate (Resources.Load ("Prefabs/" + Monster.Name)) as GameObject;
				MakeGameObject (prefab, go.transform);
			}
		}
	}
}