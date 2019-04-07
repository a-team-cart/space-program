using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenuController : MonoBehaviour
{
    // public variables -------------------------
    public Sprite m_over;                           // Over sprite when selected
    public bool m_resume;                           // If it's the resume btn
    public bool m_restart;                          // If it's the restart btn
    public bool m_quit;                             // If it's the quit btn

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

        // Get the player
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerInputs>();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    // Reset all the btns rows ------------------------------------------------------
    public void OnPressed()
    {
        // Resume Btn
        if (m_resume)
        {
            // Resume the game
            m_player.m_paused = false;
            m_player.PauseGame(false);

        }

        // Restart Btn
        if (m_restart)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        // Quit Btn
        if (m_quit)    
            Application.Quit();
    

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
