using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour {
	GameObject Tribe;

	// Use this for initialization
	void Start () {
		Tribe = GameObject.FindGameObjectWithTag ("Tribe");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();

		Debug.Log (Application.persistentDataPath);
		FileStream fs = File.Create (Application.persistentDataPath + "/" + "savegame.tst");

		bf.Serialize(fs,Tribe.GetComponent<TribeStatus>().tribeInfo);
			
		fs.Flush ();
		fs.Close ();

	}
}
