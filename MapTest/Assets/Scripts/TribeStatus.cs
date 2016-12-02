	using UnityEngine;
using System.Collections;

public class TribeStatus : MonoBehaviour {

	public TribeInfo tribeInfo ;
    GameObject gameControl;

	public GameObject tribeMemberDetailUIPrefab;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		tribeInfo = gameControl.GetComponent<SaveLoad> ().LoadSavedTribeInfo();

		if (tribeInfo == null) {
			tribeInfo = new TribeInfo();
		}

		gameObject.GetComponent<TribeMovement> ().SpawnatLastTile ();
		gameObject.GetComponent<tribeSightRange>().updateTilesInRange ();

		createTribeMemberUI ();
	}

	void createTribeMemberUI() {
		GameObject tribeUIPanel = GameObject.FindGameObjectWithTag ("TribeUIPanel");

		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			GameObject newUIDetail = GameObject.Instantiate (tribeMemberDetailUIPrefab);
			newUIDetail.GetComponent<TribeDetailUI> ().tribeMember = tm;
			newUIDetail.transform.parent = tribeUIPanel.transform;

			newUIDetail.GetComponent<TribeDetailUI> ().updateDisplay ();
			//newUIDetail.
		}
	}

	public void updateTribeDetailDisplay() {
		GameObject tribeUIPanel = GameObject.FindGameObjectWithTag ("TribeUIPanel");

		tribeUIPanel.BroadcastMessage ("updateDisplay");
	}


	// Update is called once per frame
	void Update () {
	
	}

	void DayElapsed() {
		//foodStorage =- dailyFoodNeed;

	}

	public void decrementFood() {
		Debug.Log ("Food");
		//update total daily food req
		tribeInfo.dailyFoodNeed = 0;
		foreach (Tribesman t in tribeInfo.TribeMembers) {
			tribeInfo.dailyFoodNeed += t.FoodperDay;
		}

		float newfoodStorage = tribeInfo.foodStorage - tribeInfo.dailyFoodNeed;

		//food shortage
		if (newfoodStorage < 0) {
			tribeInfo.foodStorage = 0;
			distributeFoodShortfall (newfoodStorage);
		} else {
			tribeInfo.foodStorage = newfoodStorage;
		}

	}

	void distributeFoodShortfall(float shortFall) {
		float foodShortfall = Mathf.Abs (shortFall);

		float shortagePerPerson = Mathf.RoundToInt( foodShortfall / tribeInfo.TribeMembers.Count);

		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			tm.decrementHealth (shortagePerPerson);
		}

		checkForDeadTribeMembers ();
	}

	void checkForDeadTribeMembers() {
		ArrayList removeList = new ArrayList();

		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			if (tm.Health < 0) {
				removeList.Add(tm);
			}
		}

		foreach (Tribesman tm in removeList) {
			tribeInfo.TribeMembers.Remove(tm);
		}
	}

}
