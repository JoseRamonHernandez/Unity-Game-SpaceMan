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
    
    public static GameManager sharedInstance;

    void Awake()
    {
        if(sharedInstance == null)
        {
        sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
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
