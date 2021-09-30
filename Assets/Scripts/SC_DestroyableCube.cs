using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DestroyableCube : SC_InteractableObject
{
    [SerializeField] public int clicksCount = 3;

    override public void Interact()
    {
        Hit(1);
    }

    public void Hit(int damage)
    {
        clicksCount -= damage;
        if (clicksCount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            indicate.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicate.SetActive(false);
        }
    }
}
