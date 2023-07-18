using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    private Score score;
    private GameObject player;
    float speed = .07f;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Text").GetComponent<Score>();
        player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = direction.normalized;
        direction.y = 0;

        if(direction.x < .0005f && direction.z < .0005f)
        {
            SceneManager.LoadScene("HighScore");

        }

        transform.Translate(direction * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

       
            if (collision.gameObject.tag.Equals("bullet"))
            {
                //Destroy(collision.gameObject);
                //Destroy(collision.gameObject);
                Destroy(transform.gameObject);
                Destroy(gameObject);
                //Destroy(this);
            }
            if (!collision.gameObject.tag.Equals("GameController") && !collision.gameObject.tag.Equals("bullet"))
            {
                SceneManager.LoadScene("HighScore");
            }
        
   
        score.SendMessage("plusOne");
    }

}
