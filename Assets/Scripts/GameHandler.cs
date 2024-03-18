using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

    

    [SerializeField] public Snake snake;

    private LevelGrid levelGrid;

    private void Awake() {
        instance = this;
        Score.InitializeStatic();
        Time.timeScale = 1f;

        Score.TrySetNewHighscore(200);

    }
    private void Start() {
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(20, 30);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
           
    }

    private void Paused() {
        if(IsGamePaused()) {
            GameHandler.ResumeGame();
        } else  {
            GameHandler.PauseGame();
        }
    }

    

    public static void SnakeDied() {
        bool isNewHighscore = Score.TrySetNewHighscore();
        GameOverWindow.ShowStatic(isNewHighscore);
        ScoreWindow.HideStatic();
    }

    
    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }

    public static void ResumeGame() {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }
    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }
}
