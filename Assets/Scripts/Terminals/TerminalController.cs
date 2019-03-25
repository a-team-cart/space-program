using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TerminalController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Terminal Type")]
    public bool m_selectionInterface;               // Selection interface (multiple arrays)
    public bool m_sliderInterface;                  // Slider interface
    [Space(10)]
    public GameObject m_screen;                     // Screen of the terminal
    public GameObject m_firstBtn;                   // The first area to be selected when activating the terminal
    public bool m_listenInput;                      // If the player is active on this terminal

    // private variables ------------------------
    private GameObject m_es;                        // Catch the eventSystem in the scene
    private bool m_setSelection;                    // Set selection of item only once
    private GameObject m_uiInside;                  // insideTerminalUI instructions


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Set listenInput to false per default
        m_listenInput = false;

        // Get the eventSystem
        m_es = GameObject.FindGameObjectWithTag("EventSystem");

        //get instructional UI elements in right hand corner
        m_uiInside = GameObject.FindGameObjectWithTag("insideTerminalUI");
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // If the terminal is activated by the player
        if (m_listenInput)
        {
            // Select the default area to the terminal
            if (m_firstBtn && m_setSelection)
            {
                m_es.GetComponent<EventSystem>().firstSelectedGameObject = m_firstBtn;
                m_es.GetComponent<EventSystem>().SetSelectedGameObject(m_firstBtn);
                // Don't do it again
                m_setSelection = false;
            }

            // Activate interaction on the canvas
            if (m_screen)
            {
                m_screen.GetComponent<CanvasGroup>().interactable = true;
            }

            // If the interface is a selection interface
            if (m_selectionInterface)
            {
                inputSelection();
            }

            //turn on insideTerminalUI instructions
            m_uiInside.SetActive(true);
        }
        else
        {
            // Deactivate interaction on the canvas
            if (m_screen) {
                m_screen.GetComponent<CanvasGroup>().interactable = false;
            }
            // Set selection back for next fire
            m_setSelection = true;

            //turn off insideTerminalUI instructions
            m_uiInside.SetActive(false);
        }

    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    public void inputSelection()
    {

    }
}
