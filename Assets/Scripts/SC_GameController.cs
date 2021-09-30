using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject teleported;
    // Start is called before the first frame update
    void Start()
    {
        teleported = GameObject.Find("Teleported");
        if (teleported)
        {
            player.transform.position = teleported.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
