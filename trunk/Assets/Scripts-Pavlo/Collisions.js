static var GRENADE_AMMO = 0;

function OnControllerColliderHit(hit : ControllerColliderHit)
{
	if(hit.gameObject.tag == "crateGrenades")
	{
		//destroy the ammo box
		Destroy(hit.gameObject);
		
		//add ammo to inventory
		GRENADE_AMMO += 8;
		print("YOU NOW HAVE "+ GRENADE_AMMO +" GRENADES");
		GameObject.Find("g_Count").guiText.text = ""+GRENADE_AMMO;
	}
}


var rayCastLength = 5;

function Update()
{	
	var hit : RaycastHit;
	
	//check if we're colliding
	if(Physics.Raycast(transform.position, transform.forward, hit, rayCastLength))
	{
		//...with a door
		if(hit.collider.gameObject.tag == "door")
		{
			//open the door
			hit.collider.gameObject.animation.Play("door_animation");
		}
	}
}