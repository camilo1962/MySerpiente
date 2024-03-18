using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour {

    private static ScoreWindow instance;

    private Text scoreText;
    

    private void Awake() {
        instance = this;
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        
    }

    private void Start() {
        Score.OnHighscoreChaged += Score_OnHighscoreChanged;
        UpdateHighscore();
    }
     
    private void Score_OnHighscoreChanged(object sender, System.EventArgs e) {
        UpdateHighscore();
    }

    private void Update() {
        scoreText.text = Score.GetScore().ToString();
    }

    private void UpdateHighscore()
    {
        int highscore = Score.GetHighscore();
        transform.Find("highstoreText").GetComponent<Text>().text = "RECORD\n" + highscore.ToString();
    }

    public static void HideStatic() {
        instance.gameObject.SetActive(false);
    }
    

    public static void ClearHigsScore()
    {
        
        PlayerPrefs.DeleteKey("highscore");
        PlayerPrefs.GetInt("0", 0);

    }



}