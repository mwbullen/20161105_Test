using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TribeInfo : System.Object
{

	public float dailyFoodNeed;
	public float foodStorage;

	public List<Tribesman> TribeMembers;


	public TribeInfo () //Used when creating new game
	{
		
	}
}


