/*
Pavlo Bazilinskyy
*/

function OnControllerColliderHit(hit : ControllerColliderHit)
{
	if(hit.gameObject.tag == "grenadeBox")
	{
		//Destroy the box object from game world
		Destroy(hit.gameObject);
		
		//Add grenades to ammo
		Weapons.GRENADE_AMMO += 10;
		//GameObject.Find("g_Count").guiText.text = ""+GRENADE_AMMO;
	}
}


var rayCastLength = 5;

function Update()
{	
	var hit : RaycastHit;
	
	//If a player collides
	if(Physics.Raycast(transform.position, transform.forward, hit, rayCastLength))
	{
		//A player collided with a door
		if(hit.collider.gameObject.tag == "door")
		{
			//Open the door if collision was detected
			hit.collider.gameObject.animation.Play("door_animation");
		}
	}
}