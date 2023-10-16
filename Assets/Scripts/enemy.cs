using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   public float posX = 23.0f ;
    private Rigidbody enemyRb;
    private GameObject player;

  
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -posX && CompareTag("enemy")) // destroying enemies prefabs out of frame
        {
            Destroy(gameObject);
        }
    }
}
