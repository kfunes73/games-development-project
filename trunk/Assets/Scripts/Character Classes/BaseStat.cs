/// <summary>
/// BaseStat.cs
/// Matthew Phillips
/// 18th November 2011
/// 
/// This is a base class for the in game stats
/// </summary>

using UnityEngine;

public class BaseStat  {
	
	public const int STARTING_EXP_COST = 100; // publically accessed value for all stats 

	private int _baseValue;					   // the base value for each stat
	private int _buffValue;					  // the value of any buffs
	private int _expToLevel;				 // the amount of experience for leveling
	private float _levelModifier;			// the amount of extra experience needed to go up another level
	
	/// <summary>
	/// Init, a new instance of BaseSet class
	/// </summary>
	public BaseStat(){
		Debug.Log("Base Stat Created");
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = STARTING_EXP_COST;
}
	#region Basic Setters and Getters
	/// <summary>
	/// Gets / Sets  Values
	/// </summary>
	/// <value>
	/// The _baseValue
	/// </value>
	public int BaseValue{
		get{return _baseValue; }
		set{_baseValue = value; }
	}
	/// <value>
	/// The _buffValue
	/// </value>
	public int BuffValue{
	    get{ return _buffValue; }
		set{ _buffValue = value; }
}
	/// <value>
	/// the _expToLevel
	/// </value>
	public int ExpToLevel {
		get{ return _expToLevel;}
		set{ _expToLevel = value;}
	}
	/// <value>
	/// the _levelModifier
	/// </value>
	public float LevelModifier {
		get{ return _levelModifier;}
		set{ _levelModifier = value;}
	}
	#endregion
	
	/// <summary>
	/// Calculates the experience needed to Level up
	/// </summary>
	/// <returns>
	/// A <see cref="System.Int32"/>
	/// </returns>
	private int CalculateExpToLevel(){
		return (int)(_expToLevel * _levelModifier);
	}
	/// <summary>
	/// calculates the new amount of experience needed after leveling
	/// </summary>
	public void LevelUp(){
		_expToLevel = CalculateExpToLevel();
		_baseValue++;
	}
	/// <summary>
	/// Recalculate the Adjusted base value and return it
	/// </summary>
	public int AdjustedBaseValue{
		get{return _baseValue + _buffValue;}
		
	}
}
