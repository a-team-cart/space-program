using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorDetection : MonoBehaviour
{
    // public variables -------------------------
    public GameObject m_cursor;                     // Cursor Object
    public bool m_onTerminal;                       // Cursor on terminal
    public hoverController m_borders;                         // Borders when focused on terminal

    // private variables ------------------------
    private GameObject m_selectedTerminal;          // Selected object representing a terimnal
    private playerInputs m_inputs;                  // Player object

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Clear the terminal recognition
        m_onTerminal = false;

        // Get the player object
        m_inputs = GameObject.FindGameObjectWithTag("Player").GetComponent<playerInputs>();
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // When the cursor is on terminal
        if (m_onTerminal && m_selectedTerminal)
        {
            // Activate the animation of the cursor
            m_cursor.GetComponent<cursorController>().m_expandAnim = true;
            m_cursor.GetComponent<cursorController>().m_returnAnim = false;

            // Tell the player about it
            m_inputs.m_canFocus = true;
            m_inputs.m_focusedTerminal = m_selectedTerminal;
            
        } else
        {   
            // Return the cursor to its normal state
            m_cursor.GetComponent<cursorController>().m_expandAnim = false;
            m_cursor.GetComponent<cursorController>().m_returnAnim = true;

            // Tell the player about it
            m_inputs.m_canFocus = false;
            m_inputs.m_focusedTerminal = m_selectedTerminal;
        }

        // Check when you need to make the border 
        if (m_inputs.m_focusedOnTerminal)
        {
            // Disable the cursor make the border appear
            m_borders.HoverEffect(true);
            m_cursor.SetActive(false);
        } else
        {
            // Disable the cursor make the border appear
            m_borders.HoverEffect(false);
            m_cursor.SetActive(true);
        }
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    public void OnTriggerStay(Collider col)
    {
        // If the cursor interacts/collides with a terminal 
        if (col.gameObject.tag == "Terminal")
        {
            m_onTerminal = true;
            m_selectedTerminal = col.gameObject;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        // If the cursor get out of a terminal's collider
        if (col.gameObject.tag == "Terminal")
        {
            m_onTerminal = false;
            m_selectedTerminal = null;
        }
    }
}
