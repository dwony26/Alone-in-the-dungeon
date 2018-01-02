using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour {

	public void GameStart() {
		SceneManager.LoadScene ("Game");
	}
}
