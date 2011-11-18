/// <summary>
/// Attribute.cs
/// Matthew Phillips
/// 18th November 2011
/// this class is for all the character  attributes
/// </summary>
using UnityEngine;
public class Attribute : BaseStat {
	new public const int STARTING_EXP_COST = 50; // Overrides the old Starting Cost
	private string _name;						 // The name of the attribute
	/// <summary>
	/// Initilizes a new instance of attribute
	/// </summary>
	public Attribute(){
		Debug.Log("Attribute made");
		_name = "";
		ExpToLevel = STARTING_EXP_COST;
		LevelModifier = 1.05f;
	}
	/// <summary>
	/// Gets/Sets the _name
	/// </summary>
	public string Name {
		get{return _name;}
		set{_name = value;}
	}

	
}
/// <summary>
/// a list of attributes any character may need
/// </summary>
public enum AttributeName {
	Strength,
	Mass,
	Accuracy,
	Nimbleness,
	Reactions,
	Defence,
	Speed,
	Ammo_Count
}
