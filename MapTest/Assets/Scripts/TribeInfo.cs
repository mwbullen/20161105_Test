﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TribeInfo : System.Object
{
	public int currentTileID = 125;

	public float dailyFoodNeed;
	public float foodStorage =100;

	public int defaultTribeSize = 3;

	public List<Tribesman> TribeMembers;


	public TribeInfo () //Used when creating new game
	{
		TribeMembers = createNewTribeMembers ();
	}


	List<Tribesman> createNewTribeMembers () {
		List<Tribesman> resultList = new List<Tribesman> ();

		for (int i = 1; i <= defaultTribeSize; i++) {
			resultList.Add(new Tribesman());
		}

		return resultList;
	}


	public void decrementFood() {

		dailyFoodNeed = 0;
		foreach (Tribesman t in TribeMembers) {
			dailyFoodNeed += t.FoodperDay;
		}

		dailyFoodNeed = dailyFoodNeed;

		foodStorage -= dailyFoodNeed;
	}


}


