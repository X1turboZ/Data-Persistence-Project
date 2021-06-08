using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public string playerName;
	public string bestPlayerName;
	public string lastPlayerName;
	public int points;
	public int bestScore;

	private void Awake () {
		if(Instance != null) {
			Destroy (gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
		LoadScore ();
	}

	[System.Serializable]
	class SaveData {
		public int bestScore;
		public string bestPlayerName;
		public string lastPlayerName;
	}


	public void SaveScore () {
		SaveData text = new SaveData ();
		text.bestScore = points;
		text.bestPlayerName = playerName;
		text.lastPlayerName = playerName;

		string json = JsonUtility.ToJson (text);

		File.WriteAllText (Application.persistentDataPath + "/savefile.json", json);
	}

	public void LoadScore () {
		string path = Application.persistentDataPath + "/savefile.json";
		if (File.Exists (path)) {
			string json = File.ReadAllText (path);
			SaveData data = JsonUtility.FromJson<SaveData> (json);
			bestPlayerName = data.bestPlayerName;
			bestScore = data.bestScore;
			lastPlayerName = data.lastPlayerName;
		}
	}
	public void ClearScore () {
		SaveData text = new SaveData ();
		text.bestScore = 0;
		text.bestPlayerName = "";
		text.lastPlayerName = "";

		string json = JsonUtility.ToJson (text);

		File.WriteAllText (Application.persistentDataPath + "/savefile.json", json);
	}
}


