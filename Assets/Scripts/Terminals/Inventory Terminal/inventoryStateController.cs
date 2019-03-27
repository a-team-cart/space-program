using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryStateController : MonoBehaviour
{
    // public variables -------------------------
    public int m_stockIndex = 5;                    // Number of stock in the inventory (water, snacks...)
    public int m_currentErrors = 0;                 // Counts the number of stock value that are equal to 0
    [Header("Critical Error Screen")]
    public GameObject m_errorScreen;                // GameObject that holds the error screen to display
    public GameObject m_resolveBtn;                 // GameObject that holds the resolve btn 
    
    // private variables ------------------------
    private TerminalController m_terminalManager;   // Script that controls the terminal 
    private bool m_resolving;                       // Check if the player is currently resolving a critical error


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the terminal controller script from the parent
        m_terminalManager = transform.parent.GetComponent<TerminalController>();
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Always check if all stock are in errors 
        errorScan();

    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Lookout for a power error --------------------------------------
    public void errorScan()
    {
        // If all stock value are at 0 (and the player is not currently resolving the issue)
        if (m_currentErrors >= m_stockIndex && !m_resolving)
        {
            // Set the first selection of the terminal to the resolve btn
            m_terminalManager.m_firstBtn = m_resolveBtn;
            m_terminalManager.m_setSelection = true;
            
            // Activate the errors screen
            m_errorScreen.SetActive(true);

            // Turn resolving on (to block the error screen once the player will be resolving)
            m_resolving = true;
        }


        if (m_resolving && m_currentErrors < m_stockIndex)
            m_resolving = false;
    }


    // Add or delete an error from the count -------------------------
    public void ErrorCounter(bool add)
    {
        // Add or delete a current error
        if (add)
            m_currentErrors ++;
        else
            m_currentErrors --;
    }
}
