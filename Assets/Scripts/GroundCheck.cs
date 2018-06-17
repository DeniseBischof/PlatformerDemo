using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerMovement player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.isOnGround = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.isOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isOnGround = false;
    }
}
