using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class memoryController : MonoBehaviour
{
    // public variables -------------------------
    public int m_channelOneErrors;                  // Index that keeps the number of errors in channel 1
    public int m_channelTwoErrors;                  // Index that keeps the number of errors in channel 2
    public Sprite m_full;                           // Sprite when btn is full
    public Sprite m_empty;                          // Sprite when btn is empty
    [Header("Critical Errors Screen")]
    public TerminalController m_terminalManager;    // Master monitor (parent of the terminal)
    public GameObject m_errorScreen;                // The error screen to display when in critical error
    public bool m_criticalError = false;            // Check if there's a critical error
    public GameObject m_resolveBtn;                 // Btn for the tap to resolve on the critical screen

    // private variables ------------------------
    private bool m_resolving = false;               // Check if the player is currently resolbing the issue
    private Image m_btn;                            // Image linked to this object

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the image component
        m_btn = GetComponent<Image>();
     	   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Always check for an error
        CheckForCritical();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Add or delete an error in a channel -----------------------------
    public void ErrorCount(int channelIndex, bool direction)
    {
        // Check first in which channel the error should be solve
        if (channelIndex == 1)
        {
            // Look at the direction (add or delete)
            if (direction)
                m_channelOneErrors ++;
            else if (m_channelOneErrors != 0)
                m_channelOneErrors --;
        }

        if (channelIndex == 2)
        {
            // Look at the direction (add or delete)
            if (direction)
                m_channelTwoErrors ++;
            else if (m_channelTwoErrors != 0)
                m_channelTwoErrors --;
        }
    }


    // Check for a critical error --------------------------------------
    private void CheckForCritical() 
    {
        // Check for an error in channel 1 and 2
        if (m_channelOneErrors >= 5 || m_channelTwoErrors >= 6)
            m_btn.sprite = m_full;
        else
            m_btn.sprite = m_empty;
        

        // When a critical error is found and the player is not already resolving it
        if (m_channelOneErrors >= 5 && m_channelTwoErrors >= 6 && !m_resolving)
        {
            // Set the first selection of the terminal to the resolve btn
            m_terminalManager.m_firstBtn = m_resolveBtn;
            m_terminalManager.m_setSelection = true;
            
            // Activate the error screen
            m_errorScreen.SetActive(true);

            // Turn resolving on (to block the error screen once the player will be resolving)
            m_resolving = true;
        }

        // Stop resolving
        if (m_channelOneErrors < 5 || m_channelTwoErrors < 6)
            m_resolving = false;
    }
}
