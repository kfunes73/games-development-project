var grenadeSpeed = 3.0;
var grenadePrefab:Transform; 

function Update () 
{
	//find out if a fire button is pressed
	if(Input.GetButtonDown("Fire1"))
	{
		//if(Collisions.GRENADE_AMMO > 0)
		//{
			//create the grenade prefab
			var grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
		
			//add force to the prefab
			grenade.rigidbody.AddForce(transform.forward * 2000);
			
			//Collisions.GRENADE_AMMO --;
			//GameObject.Find("g_Count").guiText.text = ""+Collisions.GRENADE_AMMO;
			//print("YOU NOW HAVE "+ Collisions.GRENADE_AMMO +" GRENADES");
		//}
	}
}