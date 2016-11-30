	using UnityEngine;
using System.Collections;

public class TribeStatus : MonoBehaviour {

	public TribeInfo tribeInfo ;
    GameObject gameControl;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		tribeInfo = gameControl.GetComponent<SaveLoad> ().LoadSavedTribeInfo();

		if (tribeInfo == null) {
			tribeInfo = new TribeInfo();
		}

		gameObject.GetComponent<TribeMovement> ().SpawnatLastTile ();
		gameObject.GetComponent<tribeSightRange>().updateTilesInRange ();

	}


	// Update is called once per frame
	void Update () {
	
	}

	void DayElapsed() {
		//foodStorage =- dailyFoodNeed;

	}
}
