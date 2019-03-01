using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Terminal Type")]
    public bool m_selesctionInterface;              // Selection interface (multiple arrays)
    public bool m_sliderInterface;                  // Slider interface
    [Space(10)]
    public GameObject m_screen;                     // Screen of the terminal

    [HideInInspector] public bool m_listenInput;    // If the player is active on this terminal

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
        // If the interface is a selection
        if (m_listenInput && m_selesctionInterface)
            inputSelection();

    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    public void inputSelection() 
    {


    }
}
