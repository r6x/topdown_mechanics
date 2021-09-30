using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_NeedExpCube : SC_InteractableObject
{
    public SC_PlayerController player;
    public float threshold = 60;
    public float heal = 15;
    override public void Interact()
    {
        Debug.Log("interact");
        player.heal(heal);
    }

    private void Start()
    {
        indicate.SetActive(false);
    }

    private void Update()
    {
        if(player != null)
        {
            if (player.getExp() >= threshold)
            {
                indicate.SetActive(true);
            } else
            {
                indicate.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            player = other.gameObject.GetComponent<SC_PlayerController>();
            Debug.Log(player);
        }
    }
}
