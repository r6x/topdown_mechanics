using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SC_TeleportCube : SC_InteractableObject
{
    public GameObject teleported;
    override public void Interact()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("123");
        } else
        {
            DontDestroyOnLoad(teleported);
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
