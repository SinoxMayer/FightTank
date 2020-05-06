using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public int width = 45;
    public int height = 35;
    public GameObject wall;
    //public GameObject player;
    private bool playerSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GenerateLevel()
    {
        //loop grip için,
        for (int x = 0; x <= width; x+=2)
        {
            for (int y = 0; y <= height; y+=2)
            {
                // duvar koyacak mıyım
              
              if (Random.value > .9f)
                {

                 
                    //duvar koy

                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);

                }
                //else if (!playerSpawned)
                //{
                //    //spawn player
                //    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                //    Instantiate(player)
                //}
            }
        } 

    }
}
