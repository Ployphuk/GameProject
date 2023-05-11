using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoints;
    private Health playerHealth;
    private UIManager uiManager;
    void Start()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    public void CheckRespawn(){

        if(currentCheckpoints == null){
            uiManager.GameOver();
            return ;
        }

        
        playerHealth.Respawn();
        transform.position = currentCheckpoints.position;
    }

    private void OntriggerEnter2D(Collider2D collision){
        if(collision.transform.tag == "CheckPoint"){
            currentCheckpoints = collision.transform;
            collision.GetComponent<Collider>().enabled = false; 
            collision.GetComponent<Animator>().SetTrigger("Appear");
        }
    }
}
