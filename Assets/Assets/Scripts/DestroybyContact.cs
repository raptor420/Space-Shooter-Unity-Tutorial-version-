using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject player;
    private GameController gamecontroller;


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
        Debug.Log(other.name);
        if(other.tag == "Boundary")
        {
            return;


        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(player, other.transform.position, other.transform.rotation);//player des animation
            gamecontroller.Gameisover();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gamecontroller.updateScore();
        
    }
}
