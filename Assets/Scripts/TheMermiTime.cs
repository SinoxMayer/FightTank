using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMermiTime : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem explosionGroundParticle;

    private float explosionTime = 5f;

    private GameManager gameManager;


    private int puan = 100;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //difference.Normalize();
        //float rotationZ = Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f,rotationZ,0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            ParticleSystem newGroundExplosion = Instantiate(explosionGroundParticle, transform.position, explosionGroundParticle.transform.rotation) as ParticleSystem;

            Destroy(newGroundExplosion.gameObject, 1);

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Duvar"))
        {

            ParticleSystem newExplosion = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation) as ParticleSystem;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(newExplosion.gameObject, explosionTime);
            gameManager.ScoreBoard(-puan);
        }
        else if (other.gameObject.CompareTag("Sınırlar"))
        {
            
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
           


                ParticleSystem newExplosion = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation) as ParticleSystem;
                Destroy(other.gameObject);
                Destroy(gameObject);
                Destroy(newExplosion.gameObject, explosionTime);
                gameManager.ScoreBoard(puan);


           
        }


    }

}
