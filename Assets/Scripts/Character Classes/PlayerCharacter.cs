

public class PlayerCharacter : BaseCharacter {

	void update(){
		Messenger<int , int>.Broadcast("Player Health Update", 80, 100);
	}
}
