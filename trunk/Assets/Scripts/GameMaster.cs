using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	public Camera mainCamara;
	public GameObject gameSettings;
	
	public float zOffset;
	public float yOffset;
	public float xOffset;
	
	public float xRotOffset;
	public float yRotOffset;
	public float zRotOffset;
	
	private GameObject _pc;
	private PlayerCharacter _pcScript;
	
	private Vector3 _playerSpawnPointPos;	// this is the position of the player's spawn point

	// Use this for initialization
	void Start () {
		_playerSpawnPointPos = new Vector3(96, 9, 47);	// position of spawn point
		GameObject go = GameObject.Find(GameSettings.PLAYER_SPAWN_POINT);
		
		if(go == null ){
			Debug.LogWarning("Cant find Player's Spawn");
			
			go = new GameObject(GameSettings.PLAYER_SPAWN_POINT);
			Debug.Log(" Created Spawn Point");
			
			go.transform.position = _playerSpawnPointPos;
			Debug.Log("Moved the Spawn Point");
		}
		_pc = Instantiate(playerCharacter, go.transform.position, Quaternion.identity)as GameObject;
	
		_pc.name = "pc";
		_pcScript = _pc.GetComponent<PlayerCharacter>();
		zOffset = -0.58f;
		yOffset = 0.3f;
		xOffset = -0.03f;
		xRotOffset = 21.45f;
		yRotOffset = 0.94f;
		zRotOffset = 0.38f;
		
		mainCamara.transform.position = new Vector3(_pc.transform.position.x + xOffset, _pc.transform.position.y +yOffset,_pc.transform.position.z + zOffset);
		mainCamara.transform.Rotate(xRotOffset, yRotOffset, zRotOffset);
		
		LoadCharacter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadCharacter(){
		GameObject gs = GameObject.Find("__GameSettings");
		if(gs == null){
			GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity)as GameObject;
			gs1.name = "__GameSettings";
		}
		GameSettings gsScript = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
		gsScript.LoadCharacterData();
	}
}
