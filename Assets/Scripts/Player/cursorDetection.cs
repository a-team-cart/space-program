using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorDetection : MonoBehaviour
{
    // public variables -------------------------
    public GameObject m_cursor;
    public bool m_onTerminal;

    // private variables ------------------------


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Clear the terminal recognition
        m_onTerminal = false;
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // When the cursor is on terminal
        if (m_onTerminal)
        {
            // Activate the animation of the cursor
            m_cursor.GetComponent<cursorController>().m_expandAnim = true;
            m_cursor.GetComponent<cursorController>().m_returnAnim = false;
        } else
        {   
            // Return the cursor to its normal state
            m_cursor.GetComponent<cursorController>().m_expandAnim = false;
            m_cursor.GetComponent<cursorController>().m_returnAnim = true;
        }
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    public void OnTriggerStay(Collider col)
    {
        // If the cursor interacts/collides with a terminal 
        if (col.gameObject.tag == "Terminal")
            m_onTerminal = true;
    }

    public void OnTriggerExit(Collider col)
    {
        // If the cursor get out of a terminal's collider
        if (col.gameObject.tag == "Terminal")
            m_onTerminal = false;
    }
}
