﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour {
	GameObject Tribe;

	string SaveTribeInfoFileName = "tribeSave.gam";
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save() {
		Tribe = GameObject.FindGameObjectWithTag ("Tribe");

		BinaryFormatter bf = new BinaryFormatter ();

		Debug.Log (Application.persistentDataPath);
		FileStream fs = File.Create (Application.persistentDataPath + "/" + SaveTribeInfoFileName);

		bf.Serialize(fs,Tribe.GetComponent<TribeStatus>().tribeInfo);
			
		fs.Flush ();
		fs.Close ();

	}

	public TribeInfo LoadSavedTribeInfo() {
		if (File.Exists (Application.persistentDataPath + "/" + SaveTribeInfoFileName)) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream fs = File.Open (Application.persistentDataPath + "/" + SaveTribeInfoFileName, FileMode.Open);

			TribeInfo savedTribeInfo = (TribeInfo) bf.Deserialize (fs);

			fs.Close ();
			return savedTribeInfo;
		}

		return null;
	}
}
