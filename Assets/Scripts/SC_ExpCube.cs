using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ExpCube : SC_InteractableObject
{
    SC_PlayerController player;
    [SerializeField]  public float expCount = 20f;
    override public void Interact()
    {
        Debug.Log(player);
        if (player != null)
        {
            player.GiveExp(expCount);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicate.SetActive(true);
            player = other.gameObject.GetComponent<SC_PlayerController>();
            Debug.Log(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicate.SetActive(false);
            player = null;
        }
    }

}
