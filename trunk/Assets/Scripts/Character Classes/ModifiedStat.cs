/// <summary>
/// ModifiedStat.cs
/// Matthew Phillips
/// 18th November 2011
/// 
/// This is the base classs for anything modifiable by attributes
/// </summary>

using System.Collections.Generic; // Generic is used for the list <>

public class ModifiedStat : BaseStat {
	
private List<ModifingAttribute> _mods; // a list of attributes that modify this stat
	private int _modValue;			   // The amounted added to the stat because of the attribute
	
	/// <summary>
	/// Initilize a new instance of ModifiedStat
	/// </summary>
	public ModifiedStat(){
		UnityEngine.Debug.Log("Modified Created");
		_mods = new List<ModifingAttribute>();
		_modValue = 0;
	}
	/// <summary>
	/// Adds the Modifier to the list of mods for the stat
	/// </summary>
	/// <param name="mod">
	/// A <see cref="ModifingAttribute"/>
	/// </param>
	public void AddModifier( ModifingAttribute mod) {
		_mods.Add(mod);
	}
	/// <summary>
	/// Calculating the mod Value
	/// Check to see if there are any Modified attributes
	/// If yes, than iterate through the list and add the AdjustedBaseValue * ratio of our _modvalue
	/// </summary>
	private void CalculateModValue(){
		_modValue = 0;
		
		if(_mods.Count > 0)
			foreach(ModifingAttribute att in _mods)
				_modValue += (int)(att.attribute.AdjustedBaseValue *att.ratio);
	}
	
	/// <summary>
	/// retrieves the Adjusted Base Value from the Base Value + Buff Value + Mod Value
	/// This overrides the previous Adjusted Base Stat in Base Stat Class
	/// </summary>
	public new int AdjustedBaseValue { get{return BaseValue + BuffValue + _modValue;}
	}
	/// <summary>
	/// Update the Instance
	/// </summary>
	public void Update() {
		CalculateModValue();
	}
	
	
	public string GetModifingAttributeString(){
		string temp = "";
		
		//UnityEngine.Debug.Log(temp);
		
		for(int cnt = 0; cnt < _mods.Count; cnt++){
			temp += _mods[cnt].attribute.Name;
			temp += "_";
			temp += _mods[cnt].ratio;
			
			if(cnt < _mods.Count - 1){
				temp += "|";
			}
			

		}
		UnityEngine.Debug.Log(temp);
		return temp;
	}
}
/// <summary>
/// A structure that holds an attribute and ratio and will be added to the Modified Stats
/// </summary>
public struct ModifingAttribute{
	public Attribute attribute; // the attribute to be used as a Mod
	public float ratio;			// the percentage increase of the attribute that will be applied
	/// <summary>
	/// the new instance of a Modifiedattribute
	/// </summary>
	/// <param name="att">
	/// A <see cref="Attribute"/>
	/// </param>
	/// <param name="rat">
	/// A <see cref="System.Single"/>
	/// </param>
	public ModifingAttribute(Attribute att, float rat){
		UnityEngine.Debug.Log("ModAttrib created");
		attribute = att;
		ratio = rat;
	}
}