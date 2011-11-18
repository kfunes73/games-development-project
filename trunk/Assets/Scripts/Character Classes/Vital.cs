/// <summary>
/// Vital.cs
/// Matthew Phillips
/// 18th November 2011
/// 
/// This Class Contain all extra functions for a characters vitals
/// </summary>
public class Vital : ModifiedStat {
	private int _curValue;	// this is the current value of the character
	/// <summary>
	/// Intialize a new instance of Vital
	/// </summary>
	public Vital() {
		_curValue = 0;
		ExpToLevel = 50;
		LevelModifier = 1.1f;
	}
	/// <summary>
	/// gets/sets CurValue
	/// When getting the _curValue make sure it is not greater than AdjustedBaseValue
	/// If it is , make it the same value
	/// </summary>
	public int CurValue{
		get{
			if(_curValue > AdjustedBaseValue)
				_curValue = AdjustedBaseValue;
			
			return _curValue;
		}
		set{ _curValue = value; }
	}
}
/// <summary>
/// this list displays the vitals the character will have
/// </summary>
public enum VitalName {
	Health,
	Ammo
	}