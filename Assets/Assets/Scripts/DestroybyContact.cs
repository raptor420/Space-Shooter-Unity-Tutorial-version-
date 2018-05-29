using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject player;
    private GameController gamecontroller;
    public int  points;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        
        if (gameControllerObject !=null)
        {

            gamecontroller = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("error cannot find script 'GameController'");

        }


    }
   void  OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.tag);
        if(other.CompareTag ("Boundary") || other.CompareTag ("enemy") )
        {
            return;


        }
        
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);

        }
        
        if (other.tag == "Player")
        {
            Instantiate(player, other.transform.position, other.transform.rotation);//player des animation
            gamecontroller.Gameisover();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gamecontroller.updateScore(points);
        
    }
}
