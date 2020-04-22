using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool ispaused = false;
    [SerializeField] private GameObject pausemenu = null;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglepause();
        }

        if(ispaused)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void togglepause()
    {
        ispaused = !ispaused;
    }
}
