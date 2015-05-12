using UnityEngine;
using System.Collections;

public class QuizButton : MonoBehaviour {
	public bool isRightAnswer;
	public void click () {
		if (isRightAnswer) {
			GameManager.instance.rightAnswer ();
			Destroy (GameObject.FindGameObjectWithTag ("Question"));
		} else {

		}
	}
}
