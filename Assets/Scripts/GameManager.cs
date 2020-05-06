using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int health = 0;
    public int maxHealth = 100;


    public TextMeshProUGUI nextWave;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI buyHelpText;


    public bool isGameActive = true;
    bool turnedOn =false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        nextWave.gameObject.SetActive(false);
        ScoreBoard(0);
     
    }

    // Update is called once per frame
    void Update()
    {
     

        if (score>600 && !turnedOn)
        {
            buyHelpText.gameObject.SetActive(true);
            turnedOn = true;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            buyHelpText.gameObject.SetActive(false);
        }
    }


    public void NextWaveRutine(int waveNumber)
    {
        nextWave.text = "Wave " + waveNumber + " is Over ";
        nextWave.gameObject.SetActive(true);


    }
   
    public void NextWaveRutineDeAct()
    {
        nextWave.gameObject.SetActive(false);
     
    }

    public void ScoreBoard(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }





}
