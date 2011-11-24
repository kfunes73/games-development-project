/*
Pavlo Bazilinskyy
*/

var grenadeSpeed = 2.8; //Velocity of a grenade
var grenadePrefab:Transform; 

function Update () 
{
	//If a button Fire was pressed
	if(Input.GetButtonDown("Fire1"))
	{
		if(Weapons.GRENADE_AMMO > 0)
		{
			//Create a grenade to shoot
			var grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
		
			//Give the grenade initial acceleration
			grenade.rigidbody.AddForce(transform.forward * 2000);
			
			Weapons.GRENADE_AMMO --; //Reduce ammo
			//GameObject.Find("g_Count").guiText.text = ""+Weapons.GRENADE_AMMO;
		}
	}
}