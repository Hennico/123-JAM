using UnityEngine;
using System.Collections;

public class MenuOnEscape : MonoBehaviour
{

    public GameObject PausePanel;
    public GameObject HelpPanel;
    bool Paused = false;

    void Start()
    {
     PausePanel.gameObject.SetActive(false);
     HelpPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                PausePanel.gameObject.SetActive(false);
                HelpPanel.gameObject.SetActive(false);
                Paused = false;
            }
            else
            {
                PausePanel.gameObject.SetActive(true);
                Paused = true;
            }
        }
    }
    public void Resume()
    {
        PausePanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        Paused = false;
    }
}