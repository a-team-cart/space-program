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
    [HideInInspector]public bool m_setSelection;    // Set selection of item only once

    // private variables ------------------------
    private GameObject m_es;                        // Catch the eventSystem in the scene
    


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Set listenInput to false per default
        m_listenInput = false;

        // Get the eventSystem
        m_es = GameObject.FindGameObjectWithTag("EventSystem");
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
                // Highlight the first button
                StartCoroutine(SelectButton());

                // Don't do it again
                m_setSelection = false;
            }

            // Activate interaction on the canvas
            if (m_screen)
                m_screen.GetComponent<CanvasGroup>().interactable = true;
            
        }
        else
        {
            // Deactivate interaction on the canvas
            if (m_screen) 
                m_screen.GetComponent<CanvasGroup>().interactable = false;
            
            // Set selection back for next fire
            m_setSelection = true;
        }

    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    private IEnumerator SelectButton()
    {
        // Wait a frame before selecting the button (so it can be highlighted)
        yield return null;
        m_es.GetComponent<EventSystem>().SetSelectedGameObject(null);
        m_es.GetComponent<EventSystem>().SetSelectedGameObject(m_firstBtn);
    }
}
