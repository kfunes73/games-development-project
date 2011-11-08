//Spawn a new object with AudioSource and Clip set, at a point in the 3D world
var myClip : AudioClip;
 
function Start () {
 AudioSource.PlayClipAtPoint(myClip, transform.position);
}