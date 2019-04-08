using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpsController : MonoBehaviour
{
    // public variables -------------------------
    public Sprite m_over;                           // Over sprite when selected

    // private variables ------------------------
    private Image m_btn;                            // The btn of this image
    private Sprite m_original;                      // Original sprite
    private playerInputs m_player;                  // Instance of the player

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the image and original sprite
        m_btn = GetComponent<Image>();
        m_original = m_btn.sprite;

    }

    // Change the select color of the btn when the player is over -------------------
    public void Select()
    {
        // Select a sprite
        m_btn.sprite = m_over;
    }

    public void Deselect()
    {
        // Select a sprite
        m_btn.sprite = m_original;
    }
}
