using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject winScreen;

	public GameObject[] questions;

	public static GameManager instance;

	private int[] questionsTaken;

	void Awake () {
		instance = this;
		questionsTaken = new int[questions.Length];
	}

	public void rightAnswer () {
		GameObject winSc = (GameObject)Instantiate (winScreen, Vector3.zero, Quaternion.identity);
		Destroy (winSc, 1);
		bool isDone = false;
		bool isTaken = false;
		int num = 0;
		int tries = 0;
		while (!isDone) {
			isTaken = false;
			num = Random.Range (0, questions.Length - 1);
			for (int j = 0; j < questions.Length; j++) {
				if (questionsTaken[j] == num) {
					isDone = false;
					isTaken = true;
					//break;
				}
			}
			if (!isTaken) isDone = true;
			tries++;
			if (tries == 9) isDone = true;
		}
		if (!isTaken) {
			StartCoroutine (loadLevel (1, num));
			questionsTaken [num] = num;
		}
		else { StartCoroutine (loadLevel (1, Random.Range (0, questions.Length - 1))); Debug.Log ("Couldn't find ne question. Loading old ones."); }
	}

	IEnumerator loadLevel (float time, int level) {
		yield return new WaitForSeconds (time);
		Instantiate (questions[level]);
	}

}
