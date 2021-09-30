using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DamageCube : SC_InteractableObject
{
    SC_PlayerController player;
    [SerializeField]  public float damageCount = 20f;
    override public void Interact()
    {
        doSmth();
    }

   private void doSmth()
    {
        if (player != null)
        {
            player.MakeDamage(damageCount);
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
