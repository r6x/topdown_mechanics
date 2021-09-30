using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SC_Gameover : MonoBehaviour
{
    public GameObject gameover, bars, description;
    // Start is called before the first frame update

   public void GameOver()
    {
       // Time.timeScale = 0f;
        bars.SetActive(false);
        gameover.SetActive(true);
    }

    public void ReloadButton()
    {
       // Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void toggleDiscription()
    {
        if (description.activeSelf)
        {
            description.SetActive(false);
        }
        else
        {
            description.SetActive(true);
        }
    }

    public void setDescriptionText(string des)
    {
        description.GetComponentInChildren<Text>().text = des;
    }
}
