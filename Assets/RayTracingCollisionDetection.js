function Update () {
 
   var up = transform.TransformDirection(Vector3.up);//vector 3 used instead of x,y,z 0,0,0
   var hit : RaycastHit;    
   Debug.DrawRay(transform.position, -up * 10, Color.green);  //10 can be changed to any distance so that the objects stop at "10", up = y axis
 
   if(Physics.Raycast(transform.position, -up, hit, 10)){ //-up = -y axis, change to different direction
      Debug.Log("Hit");    
      if(hit.collider.gameObject.name == "floor"){ //"name of item to detect collision with"
           Destroy(GetComponent(Rigidbody)); //might not need to destroy the rigidbody
      }
   }
}