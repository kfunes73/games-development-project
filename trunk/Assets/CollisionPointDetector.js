//Basic collision detection checking for two differently named objects
function OnCollisionEnter(theCollision : Collision){
 if(theCollision.gameObject.name == "Floor"){ //name of object to be tested to hit "between" then use to give points
  Debug.Log("Hit the floor");
 }else if(theCollision.gameObject.name == "Wall"){
  Debug.Log("Hit the wall");
 }
}