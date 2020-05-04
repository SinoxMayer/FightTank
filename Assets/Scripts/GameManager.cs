using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private int score = 0;
    public TextMeshProUGUI nextWave;
    public TextMeshProUGUI scoreText;
    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    { 
        nextWave.gameObject.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnMouseDown()
    {
        if (true)
        {

        }
        
    }

}
