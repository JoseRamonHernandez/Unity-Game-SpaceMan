using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Crear enumerado
public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{

    //variables
    public GameState currentGameState = GameState.menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void GameOver()
    {

    }

    public void BackToMenu()
    {

    }

    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            //Lógica de menu
        }
        else if(newGameState == GameState.inGame)
        {
            //Lógica de inGame
        }
        else if(newGameState == GameState.gameOver)
        {
            //Lógica de gameOver
        }

        this.currentGameState = newGameState;
    }
}