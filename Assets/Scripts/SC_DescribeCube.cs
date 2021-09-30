using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SC_DescribeCube : SC_InteractableObject
{

    public GameObject canvas;
    public SC_Gameover description;
    public string desription = "Красный куб - куб описания\r\nФиолетовый куб дает опыт\r\nЖелтый куб наносит урон\r\nБелый куб телепортирует\r\nБирюзовый куб можно сломать" ;


    override public void Interact()
    {
        canvas = GameObject.Find("Canvas");
        Debug.Log(canvas);
        description = canvas.GetComponent<SC_Gameover>();
        Debug.Log(description);
        description.toggleDiscription();
        description.setDescriptionText(desription);
        
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
