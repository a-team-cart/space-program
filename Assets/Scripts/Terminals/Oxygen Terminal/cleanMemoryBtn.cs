using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cleanMemoryBtn : MonoBehaviour
{
    // public variables -------------------------
    public memoryLineController[] m_memorySections;     // All the rows managed by this btn
    public bool m_oxygen;                               // Check if this is the oxygen section
    public Image m_filler;                              // Filler linked to this object
    public Color m_blue;                                // Blue default colour of the btn

    //private variables -------------------------
    private AudioManager m_audioManager;            // Instance of Audio Manager


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the AudioManager
        m_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Reset all the btns rows ------------------------------------------------------
    public void OnPressed()
    {
        // Reset all the targeted section rows
        for (int i = 0; i < m_memorySections.Length; i++)
            m_memorySections[i].ResetRow(m_oxygen);

        m_audioManager.PitchShiftSubmitEffect();
    }


    // Change the select color of the btn when the player is over -------------------
    public void Select()
    {
        // Put the filler white when on selection
        m_filler.color = Color.white;

        m_audioManager.ItemHighlighted();
    }

    public void Deselect()
    {
        // Put the filler white when on selection
        m_filler.color = m_blue;
    }
}
