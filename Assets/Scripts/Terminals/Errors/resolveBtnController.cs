using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resolveBtnController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Error Screens")]
    public GameObject m_thisScreenError;            // This screen error containing the error btn
    public GameObject[] m_otherScreens;             // Other screens affected by the error
    public TerminalController m_terminalManager;    // Terminal manager for this screen
    public GameObject m_originalBtn;                // Original first button to put there

    // private variables ------------------------
    private GameObject m_mainAlarm;                 // Main alarm in the scene
    private bool m_playing = false;                 // Bool to check if main alarm is playing 
    

    // private variables ------------------------

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
     	   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        if (!m_playing)
        {
            // Play the alarm sound
            GameObject.FindGameObjectWithTag("Alarm").GetComponent<AudioSource>().Play();
            m_playing = true;
        }
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // If the button got pressed -------------------------------------
    public void GotPressed()
    {
        // Check if there's other error screens link to this one
        if (m_otherScreens != null)
        {
            // Deactivate all other existing error screen
            for (int i = 0; i < m_otherScreens.Length; i++)
                m_otherScreens[i].SetActive(false);
        }

        // Reset original parameter for navigation on the terminal
        m_terminalManager.m_firstBtn = m_originalBtn;
        m_terminalManager.m_setSelection = true;

        // Stop Alarm
        GameObject.FindGameObjectWithTag("Alarm").GetComponent<AudioSource>().Stop();
        m_playing = false;

        // Desctivate this screen
        m_thisScreenError.SetActive(false);
    }
}
