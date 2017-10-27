using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManger : MonoBehaviour {

	public static int currentScore;
	public static int highScore;

	public static int currentLevel = 0;
	public static int unlockedLevel;

	public static void CompleteLevel() {
		if (currentLevel >= SceneManager.sceneCountInBuildSettings - 1) {
			currentLevel = 0;
		} else {
			currentLevel++;
		}
		SceneManager.LoadScene (currentLevel);

	}
}
