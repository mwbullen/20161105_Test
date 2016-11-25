using System;

[Serializable]
public class Tribesman
{
	public string Name;
	public int Age;

	public float FoodperDay;
	public float Health;

	public Tribesman ()
	{
		Name = generateRandomName();

		FoodperDay = 10f;
		Health = 100f;

		Age = UnityEngine.Random.Range (10, 50);

	}


	string generateRandomName() {
		//consonant-vowel-consonant-vowel-consonant

		int nameLength = UnityEngine.Random.Range (3, 8);


		string consonantStr = "bcdfghjklmnpqrstvwxz";
		string vowelStr = "aeiouy";

		char[] consonants = consonantStr.ToCharArray ();
		char[] vowels = vowelStr.ToCharArray ();

		string resultName = "";

		bool nextLetterisVowel = false;

		for (int i = 0; i <= nameLength; i++) {
			if (nextLetterisVowel) {
				resultName += vowels [UnityEngine.Random.Range (0, vowels.Length)];
				nextLetterisVowel = false;
			} else {
				resultName += consonants [UnityEngine.Random.Range (0, consonants.Length)];
				nextLetterisVowel = true;
			}
		}

		return resultName;
	}
}


