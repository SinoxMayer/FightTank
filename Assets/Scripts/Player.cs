using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 20f;
    private float horizantalnput;
    private float verticallnput;

    private float horizantalRange = 24f;
    private float verticalRange = 24f;
    private float horizantalNamluInput;
    private float turnSpeed = 80f;

    public AudioClip speedup;

    private AudioSource playerAudio;

    public Transform namlu;


    public Transform m_FireTransform;
    public Rigidbody m_Mermi;
    private float speed = 3500f;

    public ParticleSystem namluPatlama;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
           
            playerAudio.PlayOneShot(speedup,0.28f);
        }


        //horizantalnput = Input.GetAxis("Horizontal");
        //verticallnput = Input.GetAxis("Vertical");
        //>>>>sağa sola hareket için en basit 
        //transform.Translate(Vector3.right * horizantalnput * Time.deltaTime * moveSpeed);   // sağa sola 
        //if(transform.position.x < horizantalRange && transform.position.x > -horizantalRange)
        //transform.Translate(Vector3.right * horizantalnput * Time.deltaTime * moveSpeed);

        //if (transform.position.z < verticalRange && transform.position.z > -verticalRange)
            //transform.Translate(Vector3.forward * verticallnput * Time.deltaTime * moveSpeed);
        horizantalNamluInput = Input.GetAxis("Namlu");

        namlu.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizantalNamluInput);
        Fire();
    }


    private void Fire()
    {
     
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Rigidbody shellInstance =
            Instantiate(m_Mermi, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            shellInstance.velocity = speed * m_FireTransform.forward * Time.deltaTime;

            ParticleSystem newNamluExplosion = Instantiate(namluPatlama, m_FireTransform.position, m_FireTransform.rotation) as ParticleSystem;

            Destroy(newNamluExplosion.gameObject,0.5f);

            //GameObject instFoam = Instantiate(mermi, transform.position, Quaternion.identity);
            //Rigidbody instFoamRB = instFoam.GetComponent<Rigidbody>();

            //instFoamRB.AddForce(Vector3.up * speed);
            //Destroy(instFoam, 3f);


        }
    }

    public void PlayerPositionReset()
    {

        Vector3 originalPos = new Vector3(-1.745856f, 0.8f, -23.18391f);
        transform.position = originalPos;
    }
}
