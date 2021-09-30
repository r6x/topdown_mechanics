using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class SC_PlayerController : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask indicatedInteractableObjects;
    public int moveSpeed = 20;

    public float maxHealthPoint = 100;
    public float currentHealthPoint;

    public float expPerLevel = 100;
    public float currentExp = 0;

    public Image hpbar;
    public Image expbar;

    public GameObject canvas;

    public int clickCount;
    private NavMeshAgent _agent;

    private SC_InteractableInterface interactableObject;

    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoint = maxHealthPoint;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = moveSpeed;
        _agent.autoBraking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Click");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100f, indicatedInteractableObjects))
            {
                if(interactableObject != null)
                {
                    InteractWithObject();
                }
            }

            if (Physics.Raycast(ray, out hit, 100f, ground))
            {
                _agent.SetDestination(hit.point);
            }
        }

        if(currentHealthPoint <= 0)
        {
            SC_Gameover gameover;
            gameover = canvas.gameObject.GetComponent<SC_Gameover>();
            gameover.GameOver();
            //todo game over
        }
        hpbar.fillAmount = currentHealthPoint / maxHealthPoint;

        if(currentExp >= expPerLevel)
        {
            //todo номер уровня
            currentExp = 0;
        }
        expbar.fillAmount = currentExp / expPerLevel;
    }

    public void InteractWithObject()
    {
        interactableObject.Interact();
    }

    public float getExp()
    {
        return currentExp;
    }

    public void heal(float heal)
    {
        if(currentHealthPoint + heal <= maxHealthPoint)
        {
            currentHealthPoint += heal;
        }
    }
    public void MakeDamage(float damage)
    {
        currentHealthPoint -= damage;
    }

    public void GiveExp(float exp)
    {
        Debug.Log("Give player exps");
        currentExp += exp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            Debug.Log("Enter Interactable col");
            interactableObject = other.gameObject.GetComponent<SC_InteractableInterface>();
            Debug.Log(interactableObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            Debug.Log("Exit Interactable col");
            interactableObject = null;
        }
    }
}
