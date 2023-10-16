using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject astronautPrefab;
    private GameObject player;
    private float spawnrangeY = 4.6f;
    private float spawnrangeX = 15.0f;
    private float startdelenemy = 4.7f;
    private float repeatrateenemy = 1.0f;
    private float startdelastronaut = 8.0f;
    private float repeatrateastronaut = 6.7f;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI GameOverText;
    public bool IsGameActive;
    private int score;
    public Button restartButton;
    public GameObject titlescreen;
    public ParticleSystem openingshot;


    // Start is called before the first frame update
    void Start()

    {
        IsGameActive = true;
        titlescreen.gameObject.SetActive(true);
        openingshot.Play();
 
        score = 0; // initializing score to 0 at the beginning
        scoretext.text = " \n      \n        " + score;

        InvokeRepeating("SpawnEnemy", startdelenemy, repeatrateenemy); //delaying spawning of enemies and repeat rate
        InvokeRepeating("SpawnAstronaut", startdelastronaut, repeatrateastronaut); // delaying astronauts spawn and repetition
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void SpawnEnemy() // spawning enemy spaceships only when game is active
    {
        if (IsGameActive == true)
        {
            titlescreen.gameObject.SetActive(false);
            float spawnPosX = Random.Range(-spawnrangeX, spawnrangeX);
            float spawnPoxY = Random.Range(-spawnrangeY, spawnrangeY);

            Vector3 randomPos = new Vector3(spawnPosX, spawnPoxY, 0);

            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], randomPos, enemyPrefab[enemyIndex].transform.rotation);
        }
       

    }

    void SpawnAstronaut() //spawning astronauts only when game is active
    {
        if (IsGameActive == true)
        {
            float spawnPosX = Random.Range(-spawnrangeX, spawnrangeY);
            float spawnPoxY = Random.Range(-spawnrangeX, spawnrangeY);
            Vector3 playerPos = gameObject.transform.position;
            Vector3 randomPos = new Vector3(spawnPosX, spawnPoxY, 0);
            Instantiate(astronautPrefab, randomPos, astronautPrefab.transform.rotation);

            Debug.Log("Save me");
        }
    }


    public void keepScore(int scoretoAdd) // displaying score on screen
    {
        score += scoretoAdd;
        scoretext.text = "     \n     \n         " + score;
    }

    public void GameOver()
    {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
       
    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
  
        

       
    

   

   


        
    