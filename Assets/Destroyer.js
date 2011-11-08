//Simple Destroy Command in Start Function
 
function Start () {
 Destroy(gameObject.Find("Box"), 3); //after the gameObject ("object name"), duration to wait before destroying, for enemies try adding an if statement. ie if health=0 then destroy
}
