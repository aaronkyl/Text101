using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom,
		corridor_0
	};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell) 		{cell();} 
		else if (myState == States.sheets_0) 	{sheets_0();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.sheets_1) 	{sheets_1();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.corridor_0) 	{corridor_0();}
	}

	// State handler methods
	#region State handler methods
	// Generic cell state
	void cell () {
		text.text = "You awake in a locked prison cell. You must escape " +
					"before your captors return! There are some dirty " +
					"sheets on the bed, a mirror hanging on the wall, " +
					"and the door which is locked from the outside.\n\n" +
					"Press S to View Sheets, M to View Mirror, L to View Lock";
		if (Input.GetKeyDown (KeyCode.S)) {myState = States.sheets_0;}
		if (Input.GetKeyDown (KeyCode.M)) {myState = States.mirror;}
		if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_0;}
	}
	// Sheets state 0 (player can only return to cell state)
	void sheets_0 () {
		text.text = "These sheets are filthy! When was the last time they " +
					"were changed? Disgusting.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell;}
	}
	// Lock state where lock is still locked; only accessible from cell state
	void lock_0 () {
		text.text = "You bang on the door lock but the door refuses to budge.\n\n"+
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell;}
	}
	// Mirror state before key is taken; leads to cell_mirror state
	void mirror () {
		text.text = "The mirror hanging on the wall seems like it can be moved. "+
					"You slide it to the side and find a key taped to the wall!\n\n" +
					"Press T to Take the key or R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell;}
		if (Input.GetKeyDown (KeyCode.T)) {myState = States.cell_mirror;}
	}
	// Cell state after key has been taken from mirror
	void cell_mirror () {
		text.text = "You're standing in the middle of your cell, key in hand.\n\n" +
					"Press S to View Sheets, L to View Lock.";
		if (Input.GetKeyDown (KeyCode.S)) {myState = States.sheets_1;}
		if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_1;}
	}
	// Sheets state 1 (player can only return to cell_mirror state)
	void sheets_1 () {
		text.text = "These sheets are filthy! When was the last time they " +
					"were changed? Disgusting.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell_mirror;}
	}
	// Lock state 1 where player can unlock lock with key and end game
	void lock_1 () {
		text.text = "You look at the lock's keyhole and it appears to be " +
					"the same shape as the key in your hand.\n\n" +
					"Press O to Unlock the Lock, R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.O)) {myState = States.freedom;}
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell_mirror;}
	}
	// Freedom - End Game
	void corridor_0 () {
		text.text = "You are in a corridor. " +
					"a blood splattered hallway. You see a dark shape lurking " +
					"at the end of the hallway, but before you can figure out " +
					"what it is you feel something grab your shoulders from above " +
					"and fangs sink into your neck.";
	}

	#endregion
}
