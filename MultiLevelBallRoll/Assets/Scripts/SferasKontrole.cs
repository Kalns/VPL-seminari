using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SferasKontrole : MonoBehaviour
{
    public GameObject status;
    public Text statusText;
    Material transparent;
    Material activeLevel;
    Material activeWall;

    // Use this for initialization
    void Start()
    {
        transparent = Resources.Load("Kubs", typeof(Material)) as Material;
        activeLevel = Resources.Load("Pamatne", typeof(Material)) as Material;
        activeWall = Resources.Load("Sienas", typeof(Material)) as Material;
        for (int i = 2; i < 6; i++)
        {
            hideObjects(i);
        }
        status = GameObject.FindGameObjectWithTag("Statuss");
        statusText = status.GetComponent<Text>();
        statusText.text = "Līmenis: 1";
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lamata1"))
        {
            processLevelChange(1);
        } else if (other.gameObject.CompareTag("Lamata2"))
        {
            processLevelChange(2);
        } else if (other.gameObject.CompareTag("Lamata3"))
        {
            processLevelChange(3);
        } else if (other.gameObject.CompareTag("Lamata4"))
        {
            processLevelChange(4);
        } else if (other.gameObject.CompareTag("Kapsula"))
        {
            other.gameObject.SetActive(false);
            statusText.text = "Tu uzvarēji!";
        }
    }

    void processLevelChange(int level)
    {
        hideObjects(level);
        showObjects(level + 1);
        statusText.text = "Līmenis: " + (level + 1).ToString();
    }

    void hideObjects(int level)
    {
        GameObject[] currentLevel = GameObject.FindGameObjectsWithTag("Limenis" + level.ToString());
        GameObject[] currentWalls = GameObject.FindGameObjectsWithTag("Siena" + level.ToString());

        foreach (GameObject gameObj in currentLevel)
        {
            gameObj.GetComponent<Renderer>().material = transparent;
        }
        foreach (GameObject gameObj in currentWalls)
        {
            gameObj.GetComponent<Renderer>().material = transparent;
        }

    }

    void showObjects(int level)
    {
        GameObject[] nextLevel = GameObject.FindGameObjectsWithTag("Limenis" + level.ToString());
        GameObject[] nextWalls = GameObject.FindGameObjectsWithTag("Siena" + level.ToString());

        foreach (GameObject gameObj in nextLevel)
        {
            gameObj.GetComponent<Renderer>().material = activeLevel;
        }
        foreach (GameObject gameObj in nextWalls)
        {
            gameObj.GetComponent<Renderer>().material = activeWall;
        }
    }
}


