using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;
	
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;
	
	public void Awake(){
		Debug.Log("Log fired");
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		
		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}

	
	public string Name {
		get{ return _name;}
		set{ _name = value;}
	}
	
	public int level {
		get{ return _level;}
		set{ _level = value;}
	}
	
	public uint FreeExp {
		get{ return _freeExp;}
		set{ _freeExp = value;}
	}
	
	public void AddExp(uint exp){
		_freeExp += exp;
		
		CalculateLevel();
	}
	
	public void CalculateLevel(){
		
	}
	
	private void SetupPrimaryAttributes() {
		for(int cnt = 0; cnt< _primaryAttribute.Length; cnt++){
			_primaryAttribute[cnt] = new Attribute();
			_primaryAttribute[cnt].Name = ((AttributeName)cnt).ToString();
		}
	}
	
	private void SetupVitals(){
		for(int cnt = 0; cnt< _vital.Length; cnt++)
			_vital[cnt] = new Vital();
		
		SetupVitalModifiers();
	
		
	}
	
	private void SetupSkills(){
		for(int cnt = 0; cnt< _skill.Length; cnt++)
			_skill[cnt] = new Skill();
		
		SetupSkillModifiers();
	}
	
	public Attribute GetPrimaryAttribute(int index){
		return _primaryAttribute[index];
	}
	public Vital GetVital(int index){
		return _vital[index];
	}
	public Skill GetSkill(int index){
		return _skill[index];
	}
	
	private void SetupVitalModifiers(){
	// Health
		GetVital((int)VitalName.Health).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Mass), .33f));
		// Ammo
		GetVital((int)VitalName.Ammo).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Ammo_Count), 1));
	}
	
	private void SetupSkillModifiers(){
	// Melee Offence
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Mass), .33f));
		GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), 1f));
	// Melee Defence
		GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Mass), .33f));
		GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Defence), .5f));
	// Ranged Offence
		GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Accuracy), 1f));
		GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Reactions), .25f));
	// Ranged Defence
		GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Defence), .5f));
		GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Reactions), .25f));
	// Melee Speed
		GetSkill((int)SkillName.Melee_Speed).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .5f));
		GetSkill((int)SkillName.Melee_Speed).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Reactions), .25f));
	//Range fire Rate
		GetSkill((int)SkillName.Ranged_Fire_Rate).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .5f));
		GetSkill((int)SkillName.Ranged_Fire_Rate).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .5f));
	// Ranged Reload Rate
		GetSkill((int)SkillName.Ranged_Reload_Rate).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .5f));
		GetSkill((int)SkillName.Ranged_Reload_Rate).AddModifier(new ModifingAttribute(GetPrimaryAttribute((int)AttributeName.Reactions), .25f));
		}
	
	public void StatUpdate(){
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt].Update();
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt].Update();
	}
}
