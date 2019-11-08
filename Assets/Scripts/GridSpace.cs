using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button; //To define what we use in the program
	public Text buttonText;


	private GameController gameController;

	public void SetGameControllerReference(GameController controller)
	{
		gameController = controller;
	}


	public void SetSpace() //return the void from setSpace
	{
		buttonText.text = gameController.GetPlayerSide();
		button.interactable = false; //interactable is either we can use the button or not
		gameController.EndTurn();
	}

}
