using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{

    private static GameOverWindow instance;

    private void Awake()
    {
        instance = this;

        transform.Find("ContinuarBtn").GetComponent<Button_UI>().ClickFunc = () =>
        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        };

        Hide();
    }

    public static void ShowStatic(bool isNewHighscore)
    {
        instance.Show(isNewHighscore);
    }


    private void Show(bool isNewHighscore) {
        gameObject.SetActive(true);

        transform.Find("newHighscoreText").gameObject.SetActive(isNewHighscore);

        transform.Find("scoreText").GetComponent<Text>().text = Score.GetScore().ToString();
        transform.Find("highscoreText").GetComponent<Text>().text = "HIGHSCORE" + Score.GetHighscore();
    }

    private void Hide()  {
        gameObject.SetActive(false);
    }
}

    
