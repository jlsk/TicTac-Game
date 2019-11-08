using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Player {
	public Image Panel;
	public Text text;
}

[System.Serializable] // This is to allowed the fucntion to appear in unity such as vector3. same function
public class PlayerColor {
	public Color panelColor;
	public Color textColor;
}



public class GameController : MonoBehaviour {

	public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor innactivePlayerColor;


	private string playerSide;
	private int moveCount;


	void Awake() //This is what code run in the start
	{
		SetGameControllerReferenceOnButtons();
		playerSide = "X";
		gameOverPanel.SetActive(false); //To disable the game over panel during game start
		moveCount = 0;
		restartButton.SetActive(false); //To disable the play again button during game start
		SetPlayerColors(playerX, playerO); // To set which player turn in color
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
		}
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}


	public void EndTurn()
	{
		moveCount++;
		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
		{
			GameOver(playerSide);
		}

		if (moveCount >= 9)
		{
			GameOver ("draw");
		}

		ChangeSides();
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
		if(playerSide == "X")
		{
			SetPlayerColors(playerX, playerO);
		} 
		else 
		{
			SetPlayerColors(playerO, playerX);
		}
	}

	void SetPlayersColors (Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.Panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;

	}


	void GameOver(string winningPlayer)
	{
		SetBoardInteractable(false);
		//SetGameOverText (playerSide + " Wins!");
		//restartButton.SetActive(true);
		if (winningPlayer == "draw")
		{
			SetGameOverText("It's a Draw!");
		} else
		{
			SetGameOverText(winningPlayer + " Wins!");
		}
		restartButton.SetActive(true);
	}


	void SetGameOverText (string value)
	{
		gameOverPanel.SetActive(true);
		gameOverText.text = value;
	}

	public void RestartGame ()
	{
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive(false);
		SetBoardInteractable(true);
		restartButton.SetActive(false);
		SetPlayerColors(playerX, playerO);

		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].text = "";
		}
	}

	void SetBoardInteractable (bool toggle)
		{
			for (int i = 0; i < buttonList.Length; i++)
			{
				buttonList[i].GetComponentInParent<Button>().interactable = toggle;
			}
}

	}
