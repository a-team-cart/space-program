using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manualBtnController : MonoBehaviour
{
    // public variables -------------------------
    public employeeManualController m_manualManager;    // Object holding the manual controller
    public bool m_direction;                            // Direction of the btn (true for next, false for previous)
    [Header("Over State")]
    public bool m_changeSprite;                         // If the over effect is changing the sprite
    public Sprite m_overSprite;                         // The sprite to display on over if it is needed

    // private variables ------------------------
    private Image m_btn;                                // The image component linked to the object
    private Color m_originalColor;                      // Original colour of the sprite
    private Sprite m_originalSprite;                    // Original sprite of the btn


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the image component
        m_btn = GetComponent<Image>();

        // Pick the originals
        m_originalColor = m_btn.color;
        m_originalSprite = m_btn.sprite;  
    }


    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // If the button got pressed -------------------------------------
    public void GotPressed()
    {
        // Change page if pressed
        m_manualManager.ChangePage(m_direction);
    }

    // Select a new btn to be selected ---------------------------------
    public void ChangeSelection(Selectable nextBtn)
    {
        // Select a new Btn to over
        nextBtn.Select();
    }

    // If the button got overed --------------------------------------
    public void IsOver(bool over)
    {
        // Change the over state of the object (sprite or colour)
        if (m_changeSprite && over)
            m_btn.sprite = m_overSprite;
        else if (over)
            m_btn.color = Color.white;

        // On deselection, bring back the originals
        if (!over)
        {
            m_btn.sprite = m_originalSprite;
            m_btn.color = m_originalColor;
        }
    }
}
