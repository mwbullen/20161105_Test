using UnityEngine;
using System.Collections;

public class TurnManagement : MonoBehaviour {
	public GameObject tribeFoodStorageTxt;
	GameObject tribe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void finishMove() {
		//Debug.Log ("Finish Move");
		tribe = GameObject.FindGameObjectWithTag ("Tribe");


		tribe.GetComponent<TribeStatus> ().decrementFood();
		//gameObject.GetComponent<TribeStatus> ().updateTribeDetailDisplay ();

		updateUIInfo ();

		gameObject.GetComponent<SaveLoad> ().Save ();
	}

	public void updateUIInfo() {

		tribeFoodStorageTxt.GetComponent<UnityEngine.UI.Text> ().text = "Food storage: " + tribe.GetComponent<TribeStatus> ().tribeInfo.foodStorage;

		foreach  (GameObject uiDetail in GameObject.FindGameObjectsWithTag("TribeDetailUI")){
			uiDetail.GetComponent<TribeDetailUI> ().updateDisplay ();
		}

	}
}
