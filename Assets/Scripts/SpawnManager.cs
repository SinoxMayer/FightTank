using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Başlık Attım2")]
    private float spawnRate = 1.5f;
    public GameObject enemys;

    private int enemyNumber = 0;
    private int maxEnemyNumber = 0;
    public int zorlukseviyesi = 1;
    private int maxEnemyCountCal = 0;
    private GameManager gameManager;
    private int waitForNextWave = 15;



    // Start is called before the first frame update
    void Start()
    {
       
       
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()

    {
      
       
    }

   void CountEnemy()
    {
        enemyNumber = (GameObject.FindGameObjectsWithTag("Enemy")).Length;
        Debug.Log(enemyNumber);
       
    }
    IEnumerator SpawnTarget()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            CountEnemy();
            maxEnemyCountCal = zorlukseviyesi * 2 + 5;
            switch (zorlukseviyesi)
            {
                case 1:

                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                      
                    }
                    break;
                case 2:
 
                   
                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                    }

                    break;
                case 3:
                   
                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                    }

                    break;
                case 4:

                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                    }

                    break;
                case 5:

                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                    }

                    break;
                case 6:

                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                    }

                    break;
                case 7:

                    if (gameManager.isGameActive && enemyNumber <= maxEnemyCountCal)
                    {
                        Instantiate(enemys, RandomSpawnPosition(), enemys.transform.rotation);
                        maxEnemyNumber++;
                    }
                    if (maxEnemyNumber > maxEnemyCountCal)
                    {
                        gameManager.NextWaveRutine(zorlukseviyesi);
                        yield return new WaitForSeconds(waitForNextWave);
                        gameManager.NextWaveRutineDeAct();
                        zorlukseviyesi++;
                        maxEnemyCountCal += maxEnemyNumber;
                        maxEnemyNumber = 0;
                    }

                    break;


            }
            

          
            

        }
    }

    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = RandomSquareIndex();
 

        Vector3 spawnPosition = new Vector3(spawnPosX,0, 22);
        return spawnPosition;

    }
    int RandomSquareIndex()
    {
        return Random.Range(-19 ,22);
    }

    

}
