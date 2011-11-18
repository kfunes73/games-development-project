/// <summary>
/// Skill.cs
/// Matthew Phillips
/// 18th November 2011
/// 
/// the skills the character will have
/// </summary>
public class Skill : ModifiedStat {
	
	private bool _known;	// does the player know the skill?
	/// <summary>
	/// Initilize a new instance
	/// </summary>
	public Skill() {
		_known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;
	}
	/// <summary>
	/// get / set for Konwn
	/// </summary>
	public bool Known {
		get{return _known;}
		set{ _known = value;}
	}

}
/// <summary>
/// A list of skills the player can learn
/// </summary>
public enum SkillName{
	Melee_Offence,
	Melee_Defence,
	Ranged_Offence,
	Ranged_Defence,
	Melee_Speed,
	Ranged_Fire_Rate,
	Ranged_Reload_Rate
}