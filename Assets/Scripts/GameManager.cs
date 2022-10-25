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

    private playerController controller;

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
        controller = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit"))
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
            MenuManager.sharedInstance.ShowMainMenu();
        }
        else if(newGameState == GameState.inGame)
        {
            //Lógica de inGame
            LevelManager.sharedInstance.RemoveAllLevelBlocks();
            LevelManager.sharedInstance.GenerateInitialBlock();
            controller.StartGame();
            MenuManager.sharedInstance.HideMainMenu();
        }
        else if(newGameState == GameState.gameOver)
        {
            //Lógica de gameOver
            MenuManager.sharedInstance.ShowMainMenu();
        }

        this.currentGameState = newGameState;
    }

    void ReloadLevel()
    {
            LevelManager.sharedInstance.GenerateInitialBlock();
            controller.StartGame();
        
    }
}
