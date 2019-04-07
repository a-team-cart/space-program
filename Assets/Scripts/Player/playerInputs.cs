using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class playerInputs : MonoBehaviour
{
    // public variables -------------------------
    public bool m_canFocus;                         // Able to focus on a Terminal
    public bool m_focusedOnTerminal;                // If the Player is currently on a Terminal
    [Header("Selected Terminal")]
    public GameObject m_focusedTerminal;            // Which terminal is it in focus
    [Header("Intro Door")]
    public bool m_openDoor = true;                  // Can you open a door?
    public doorController m_firstDoor;              // The door that needs to open after the tutorial
    [Header("Pause Menu")]
    public GameObject m_pauseMenu;                  // The pause menu in the scene
    public GameObject m_resumeBtn;                  // Resume btn on the pause menu


    // private variables ------------------------
    private FirstPersonController m_fps;            // Controller of the fps movement
    private GameObject m_gm;                        // The Game manager in the scene
    private bool m_firstTime = true;                // The first you get out of a terminal, activate something
    [HideInInspector]public bool m_paused;          // If the game is paused
    private GameObject m_es;                        // Instance of the event manager

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the fps controller
        m_fps = gameObject.GetComponent<FirstPersonController>();

        // The the gm
        m_gm = GameObject.FindGameObjectWithTag("GameController");

        // Get the event system
        m_es = GameObject.FindGameObjectWithTag("EventSystem");
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // If the player press Fire1 and can focus on a terminal
        if (m_canFocus && Input.GetButtonDown("Fire1") && !m_paused)
        {   
            // Focus on the selected terminal and activate it
            m_focusedOnTerminal = true;
            m_focusedTerminal.GetComponent<TerminalController>().m_listenInput = true;
            m_gm.GetComponent<GameManager>()._isWorking  = true;
        }


        // If the player press Fire2 while focusing on a terminal
        if (m_canFocus && Input.GetButton("Fire2") && !m_paused)
        {
            m_focusedOnTerminal = false;
            m_focusedTerminal.GetComponent<TerminalController>().m_listenInput = false;
            m_gm.GetComponent<GameManager>()._isWorking  = false;

            // Activate the door when getting out of the intro
            if (m_firstTime && m_openDoor)
            {
                // Disable first time and open the door
                m_firstTime = false;
                m_firstDoor.Open();
            }
        }


        // Able or disable player movements
        if (m_focusedOnTerminal)
            m_fps.enabled = false;
        else if (!m_paused)
            m_fps.enabled = true;

        // Catch when paused
        if (Input.GetButtonDown("Cancel"))
        {
            m_paused = !m_paused;
            PauseGame(m_paused);
        }


    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    
    // Function when pausing the game
    public void PauseGame(bool active)
    {
        if (active)
        {
            // Make the menu appear
            m_pauseMenu.SetActive(true);
            // Stop time in the scene
            m_fps.enabled = false;
            Time.timeScale = 0f;
            // Select the button
            StartCoroutine(SelectButton());
            
        } else
        {
            // Make the menu disappear
            m_pauseMenu.SetActive(false);
            // Stop time in the scene
            m_fps.enabled = true;
            Time.timeScale = 1f;
        }
    }

    private IEnumerator SelectButton()
    {
        // Wait a frame before selecting the button (so it can be highlighted)
        yield return null;
        m_es.GetComponent<EventSystem>().SetSelectedGameObject(null);
        m_es.GetComponent<EventSystem>().SetSelectedGameObject(m_resumeBtn);
    }
}
