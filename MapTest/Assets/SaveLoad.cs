using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour {
	GameObject Tribe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save() {
		Tribe = GameObject.FindGameObjectWithTag ("Tribe");

		Debug.Log (Application.persistentDataPath);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/" + "savegame.tst");

		foreach (GameObject g in  GameObject.FindGameObjectsWithTag("Character")) {
			

			bf.Serialize(fs,  null);
		}


		fs.Close ();

	}
}
