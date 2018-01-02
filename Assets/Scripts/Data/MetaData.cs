using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class MetaData {

	public List<Quest> QuestList;
	public List<Enemy> EnemyList;
	public List<Monster> MonsterList;
	public List<Item> ItemList;

	public int MineHealth;	// 1층당 100씩 증가
	public int OrcMinerPower;
	public int UpgradeGold;
	 
	public int GetMonsterPower() {
		int Power = 0;
		List<Monster> MonsterList = DataController.Instance.metaData.MonsterList;
		foreach (Monster Monster in MonsterList) {
			if (Monster.Floor <= DataController.Instance.gameData.Floor) {
				Power += Monster.Power;
			}
		}
		return Power;
	}
}
