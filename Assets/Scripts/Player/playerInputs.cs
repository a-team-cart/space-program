using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class playerInputs : MonoBehaviour
{
    // public variables -------------------------
    public bool m_canFocus;                         // Able to focus on a Terminal
    public bool m_focusedOnTerminal;                // If the Player is currently on a Terminal
    [Header("Selected Terminal")]
    public GameObject m_focusedTerminal;            // Which terminal is it in focus?


    // private variables ------------------------
    private FirstPersonController m_fps;            // Controller of the fps movement
    private GameObject m_gm;                        // The Game manager in the scene

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the fps controller
        m_fps = gameObject.GetComponent<FirstPersonController>();

        // The the gm
        m_gm = GameObject.FindGameObjectWithTag("GameController");
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // If the player press Fire1 and can focus on a terminal
        if (m_canFocus && Input.GetButtonDown("Fire1"))
        {   
            // Focus on the selected terminal and activate it
            m_focusedOnTerminal = true;
            m_focusedTerminal.GetComponent<TerminalController>().m_listenInput = true;
            m_gm.GetComponent<GameManager>()._isWorking  = true;
        }


        // If the player press Fire2 while focusing on a terminal
        if (m_canFocus && Input.GetButton("Fire2"))
        {
            m_focusedOnTerminal = false;
            m_focusedTerminal.GetComponent<TerminalController>().m_listenInput = false;
            m_gm.GetComponent<GameManager>()._isWorking  = false;
        }


        // Able or disable player movements
        if (m_focusedOnTerminal)
            m_fps.enabled = false;
        else
            m_fps.enabled = true;
        
    }
}
