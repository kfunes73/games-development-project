/// <summary>
/// VitalBar.cs
/// 18th November 2011
/// Matthew Phillips
/// 
/// this is responsible for displaying all vitals
/// </summary>

using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	
	public bool _isPlayerHealthBar;
	private int _maxBarLength; // maximum health bar length
	private int _curBarLength; // current health bar length
	private GUITexture _display;
	// Use this for initialization
	void Start () {
		//_isPlayerHealthBar = true;// tells if the healthbar is the player's or the mob
		_display = gameObject.GetComponent<GUITexture>();
		
		_maxBarLength = (int)_display.pixelInset.width;
		OnEnable();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// this is called when the object is Enabled
	public void OnEnable(){
		if(_isPlayerHealthBar)
		Messenger<int , int>.AddListener("player health update", OnChangeHealthBarSize);
			else
				Messenger<int , int>.AddListener("mob health update", OnChangeHealthBarSize);
	
	}
	// this is called when the object is disabled
	public void OnDisable(){
		if(_isPlayerHealthBar)
		Messenger<int, int>.RemoveListener("player health update", OnChangeHealthBarSize);
		else
			Messenger<int, int>.RemoveListener("mob health update", OnChangeHealthBarSize);
		
	}
	
	public void OnChangeHealthBarSize(int curHealth, int maxHealth){	// calculates the size of the health bar
		Debug.Log("We heard an event: curHealth = "+ curHealth + "- maxHealth -" + maxHealth);
		_curBarLength = (int)(curHealth / (float)maxHealth) * _maxBarLength;	// this calculates the current health bar length based on the player's health percentage
		_display.pixelInset = new Rect(_display.pixelInset.x, _display.pixelInset.y, _curBarLength, _display.pixelInset.height);
	}
	// setting the healthbar to the player or mob
	public void SetPlayerHealth(bool b){
		_isPlayerHealthBar = b;
	}
}
