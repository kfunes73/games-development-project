/*
Pavlo Bazilinskyy
*/

var creationTime = Time.time;
var explosionPrefab : Transform;
var lifeTime = 3;

function Awake()
{
	creationTime = Time.time;
}

function Update () 
{
	if(Time.time > (creationTime+lifeTime))
	{
		Destroy(gameObject);
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
	}
}