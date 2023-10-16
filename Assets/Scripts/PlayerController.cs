using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    
    public float yRange = 2.4f;
    public float speed = 14.0f;
    public bool hasAstronaut = false;
    private SpawnManager spawnManagerref;// referring to SpawnManager script to update score because the collision is happening here
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip hasAstroSound;
    public GameObject powerupIndicator;
    public AudioClip KillingEnemyswithPowerupSound;
    public ParticleSystem Explosion;
    public ParticleSystem BigExplosion;
    public float horizontalinput;







    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        spawnManagerref = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();// Getting the spawnmanager script
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow)) transform.position += Vector3.up; // Spaceships moves up
        if (Input.GetKeyDown(KeyCode.DownArrow)) transform.position += Vector3.down; //Spaceship moves down

        powerupIndicator.transform.position = transform.position + new Vector3(-2.0f, 0, 0); // keeping powerup indicator at the tail of spaceship

        //boundary of player

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange);
        }


        if (transform.position.y > yRange)
        {

            transform.position = new Vector3(transform.position.x, yRange);
        }


    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" && !hasAstronaut) // when player collides with enemy
        {
             Explosion.Play();
             BigExplosion.Play();

             playerAudio.PlayOneShot(crashSound, 0.3f);
             Destroy(gameObject, 0.6f);
             spawnManagerref.GameOver();
            powerupIndicator.gameObject.SetActive(false);

            Debug.Log("You collided with an enemy");
            

        }


        if (other.tag == "astronaut") // when player collides with astronaut 
        {
            
            hasAstronaut = true;
            playerAudio.PlayOneShot(hasAstroSound);
            

            powerupIndicator.gameObject.SetActive(true); // player picking up powerup

            Destroy(other.gameObject, 0.1f);

            spawnManagerref.keepScore(1);
            StartCoroutine(hasAstronautTimer());
           

            Debug.Log("Congratulations, you saved an astronaut and you have 7 secs special power");

        }


        if (other.tag== "enemy" && hasAstronaut) // when player has picked up astronaut and special power to destroy enemy
        {
            playerAudio.PlayOneShot(KillingEnemyswithPowerupSound);
            

            Destroy(other.gameObject, 0.1f);
            Debug.Log("You killed an enemy");
        }
    }


    IEnumerator hasAstronautTimer() // player  will have astronaut's power indicator for 5 secs
    {

        yield return new WaitForSeconds(5);
        powerupIndicator.gameObject.SetActive(false);
        hasAstronaut = false;
        
    }
  
}










