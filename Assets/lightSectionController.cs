using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightSectionController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Button State")]
    public Sprite m_onSprite;                       // On sprite state
    public Sprite m_offSprite;                      // Off sprite state
    public bool m_sectionOn;                        // State of the under controlled section
    [Header("Other Objects Linked")]
    public lightBtnController[] m_childBtn;         // Link to the btns on the main power view
    public bool m_isOffBtn;                         // State if this is a section off btn

    // private variables ------------------------
    private bool m_called = true;                   // Only change one time 

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
        // Continusly check for a change in the terminal
        checkSectionState();


        // Update for a change (not directly pressing the btn)
        if (m_sectionOn && m_called)
        {
            // Do it once per call
            m_called = false;

            // Change btns srpite state (depending on type on/off)
            if (!m_isOffBtn)
                gameObject.GetComponent<Image>().sprite = m_onSprite;
            else
                gameObject.GetComponent<Image>().sprite = m_offSprite;
        }
        else if (m_called)
         {
            // Do it once per call
            m_called = false;

            // Change btns srpite state (depending on type on/off)
            if (!m_isOffBtn)
                gameObject.GetComponent<Image>().sprite = m_offSprite;
            else
                gameObject.GetComponent<Image>().sprite = m_onSprite;
        }
    }


    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Check if there's a change in the section ---------------------
    private void checkSectionState()
    {
        // Catch the current state
        bool current = m_sectionOn;
        int activeNumber = 0;

        // Check if at least one button is active in the section
        for (int i = 0; i < m_childBtn.Length; i++)
        {
            // Check the state (add one if its on)
            if (m_childBtn[i].m_on)
                activeNumber ++;
        }

        // If there's at least one btn, section is active
        if (activeNumber > 0)
            m_sectionOn = true;
        else
            m_sectionOn = false;
            
        // Check if a change has been spot
        if (m_sectionOn != current)
            m_called = true;
    }


    // When btn get pressed -----------------------------------------
    public void GotPressed()
    {
        // First check type of btn and determine the sitch
        if (m_isOffBtn && m_sectionOn)
        {
            // Deactivate all child btn
            for (int i = 0; i < m_childBtn.Length; i++)
                m_childBtn[i].masterState(false);
        }
        else if (m_isOffBtn && !m_sectionOn) 
        {
            // Activate all child btn
            for (int i = 0; i < m_childBtn.Length; i++)
                m_childBtn[i].masterState(true);
        }


        // Same if it's a on btn (but in revere!)
        if (!m_isOffBtn)
        {
            // See first if all the btn are already active
            bool allActive = true;

            // Scan all btns to see if they are already all active
            for (int i = 0; i < m_childBtn.Length; i++)
            {
                if (!m_childBtn[i].m_on)
                {
                    allActive = false;
                    break;
                }
            }

            // If all btn were not yet active
            if (!allActive)
            {
                // Activate all child btn
                for (int i = 0; i < m_childBtn.Length; i++)
                    m_childBtn[i].masterState(true);
            }
            else // otherwise
            {
                // Deactivate all child btn
                for (int i = 0; i < m_childBtn.Length; i++)
                    m_childBtn[i].masterState(false);
            }
        }
    }
}
