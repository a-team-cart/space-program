using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminalController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Terminal Type")]
    public bool m_selectionInterface;               // Selection interface (multiple arrays)
    public bool m_sliderInterface;                  // Slider interface
    [Space(10)]
    public GameObject m_screen;                     // Screen of the terminal
    public bool m_listenInput;                      // If the player is active on this terminal

    // private variables ------------------------


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Set listenInput to false per default
        m_listenInput = false;
        

    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {

        // If the terminal is activated by the player
        if (m_listenInput)
        {    
            // If the interface is a selection interface
            if (m_selectionInterface)
                inputSelection();
        }

    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    public void inputSelection() 
    {
        // Silence is gold
    }
}
