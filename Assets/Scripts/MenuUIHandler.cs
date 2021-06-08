using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//#if UNITY_EDITOR
using UnityEditor;
//#endif
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
	[SerializeField] private InputField EnterNameField;
	[SerializeField] private Text BestScoreText;
	string playerName;
	string bestPlayerName;
	string lastPlayerName;
	int bestScore;

	private void Start () {
		bestPlayerName = GameManager.Instance.bestPlayerName;
		bestScore = GameManager.Instance.bestScore;
		lastPlayerName = GameManager.Instance.lastPlayerName;

		Debug.Log (lastPlayerName);
		if (lastPlayerName != "") {
			EnterNameField.text = lastPlayerName;
		}
	}

	public void StartNew () {
		playerName = EnterNameField.text;
		if (playerName != "") {
			GameManager.Instance.playerName = playerName;
			SceneManager.LoadScene (1);
		}
		else {
			Debug.Log ("–¼‘O‚ð“ü—Í‚µ‚Ä‚­‚¾‚³‚¢");
		}
	}

	public void Exit () {
		GameManager.Instance.SaveScore ();

#if UNITY_EDITOR
		EditorApplication.ExitPlaymode ();
#else
		Application.Quit();
#endif
	}

	public void Claer () {
		GameManager.Instance.ClearScore ();
		bestPlayerName = "";
		bestScore = 0;
		BestScoreText.text = "Best Score";
	}
	public void LateUpdate () {
		if(bestPlayerName != "") {
			BestScoreText.text = "Best Score : " + bestPlayerName + " : " + bestScore;
		}
	}
}
