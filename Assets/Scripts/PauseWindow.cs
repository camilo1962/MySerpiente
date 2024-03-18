using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PauseWindow : MonoBehaviour
{
    private static PauseWindow instance;

    private void Awake()
    {
        instance = this;

        //transform.Find("resumeBtn").GetComponent<Button_UI>().ClickFunc = () => GameHandler.ResumeGame();

        //transform.Find("mainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.MainMenu);

       Hide();
    }
    private void Show()
    {
        gameObject.SetActive(false);
    }

    private void Hide()
    {
        gameObject.SetActive(true);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }
    public static void HideStatic() {
        instance.Hide();
    }
}