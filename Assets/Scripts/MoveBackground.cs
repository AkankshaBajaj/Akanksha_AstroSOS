using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    private SpawnManager spawnManagerref;
    private float speed = 6;
    // Start is called before the first frame update

    void Start()
    {
        spawnManagerref = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    { 
  
        if (spawnManagerref.IsGameActive==true)
            
                {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}

