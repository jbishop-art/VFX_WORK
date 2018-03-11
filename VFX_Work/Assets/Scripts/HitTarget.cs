using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{



	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        //Detects if player touches BadStuff.
        if (col.gameObject.tag == "Target")
        {
            Destroy(gameObject);
            Debug.Log("HIT HIT HIT");

            //Instantiate(pDPrefab, playerLoc, Quaternion.identity);

            //GameObject.Find("DeathSound").GetComponent<AudioSource>().enabled = false;
            //GameObject.Find("DeathSound").GetComponent<AudioSource>().enabled = true;


            //GameObject.Find("Player(Clone)").transform.position = spawnPoint;

        }




    }
}
