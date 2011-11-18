using UnityEngine;
using System.Collections;

public class PlayerAmmo : MonoBehaviour {
	public int maxAmmo = 100;
	public int curAmmoClip = 10;
	public int curAmmo = 10;
	
	
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentAmmo(0);
	}
	
	void OnGUI() {
		GUI.Box(new Rect(10, 40, 176, 20), curAmmo + "/" + curAmmoClip + "   stock: " + maxAmmo);
		}


	
	public void AddjustCurrentAmmo(int adj) {
		curAmmo += adj;
		
		if(curAmmo < 0)
			curAmmo = 0;
		
		while (curAmmo < 1){
			
			if(maxAmmo != 0)
				curAmmo = 10;
				maxAmmo = maxAmmo -10;
		}
		
		
		if(curAmmo > curAmmoClip)
			curAmmo = curAmmoClip;
		
		if(curAmmo > maxAmmo)
			curAmmo = maxAmmo;
		
		if(maxAmmo < 0)
			maxAmmo = 0;
		
	}
}