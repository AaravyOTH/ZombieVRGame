using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyModel;
    int counter = 200;
    Random rand = new Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter--;
        if (counter < 0)
        {
               int i= rand.Next(5);
            if(i == 1)
                Instantiate(enemyModel, transform.position, transform.rotation);
            
            counter = 200;
        }
    }

}
