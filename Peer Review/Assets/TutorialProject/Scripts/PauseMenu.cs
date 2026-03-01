using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    GameObject playerObject;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject menuList;

    [SerializeField] Animator pauseAnimatior;
    [SerializeField] float closeMenuDelay;
    float closeMenuTimer ;
    bool timerRunning;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        ResetPauseUI();
        pauseAnimatior.updateMode = AnimatorUpdateMode.UnscaledTime;
        closeMenuTimer = closeMenuDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeMenuTimer >= 0f)
        {
            closeMenuTimer -= Time.deltaTime;

        }
        if (closeMenuTimer < 0 && timerRunning)
        {
            pauseMenuObject.SetActive(false);
            timerRunning = false;
        }

    }

    void OnPauseMenu(InputValue value)
    {


        if (!isPaused) 
        {
            PauseGame();

        }
        else { 
            UnPauseGame();
        }
    }

    void PauseGame()
    {
     


        isPaused = true;
        Time.timeScale = 0;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuObject.SetActive(true);
        pauseAnimatior.SetBool("OpenMenu", true);



    }

    public void UnPauseGame()
    {


        isPaused = false;
        Time.timeScale = 1;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        closeMenuTimer = closeMenuDelay; //Start countdown to deactivate menu
        timerRunning = true;

        ResetPauseUI();

        pauseAnimatior.SetBool("OpenMenu", false);




    }

    void ResetPauseUI()
    {
        for (int i = 0; i < menuList.transform.childCount; i++ )
        {
            menuList.transform.GetChild(i).gameObject.SetActive(false);
        }
        pauseStartMenuObject.SetActive(true);


    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
