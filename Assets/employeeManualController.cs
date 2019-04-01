﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class employeeManualController : MonoBehaviour
{
    // public variables -------------------------
    public Sprite[] m_pages;                        // Array that contains all the pages for the employee
    [Header("Buttons")]
    public GameObject m_arrowLeft;                  // Button that holds the left arrow
    public GameObject m_arrowRight;                 // Button that holds the right arrow
    public GameObject m_beginBtn;                   // Button that display on the front page of the employee


    // private variables ------------------------
    private Image m_screen;                         // The screen of this terminal
    private int m_currentPage;                      // Page number to display
    private int m_maxPage;                          // The max number of pages

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Check what's the max number of pages based on the page array
        m_maxPage = m_pages.Length;

        // Get the image component and set the front page of the manual to start
        m_screen = GetComponent<Image>();
        m_currentPage = 0;
        m_screen.sprite = m_pages[m_currentPage];
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Scan to know which btn should be included -----------------------
    private void ScanBtn()
    {
        // Btn to show on the front page
        if (m_currentPage == 0)
        {
            m_beginBtn.SetActive(true);
            m_arrowLeft.SetActive(false);
            m_arrowRight.SetActive(false);
        }

        // Btn to show in the array
        if (m_currentPage == 0)
        {
            m_beginBtn.SetActive(false);
            m_arrowLeft.SetActive(true);
            m_arrowRight.SetActive(true);
        }

        // Btn to show on the last page
        if (m_currentPage == 0)
        {
            m_beginBtn.SetActive(false);
            m_arrowLeft.SetActive(true);
            m_arrowRight.SetActive(false);
        }

    }

    // If the screen needs to change page ------------------------------
    public void ChangePage(bool next)
    {
        // If next has been trigger, make sure it's in the arrays lenght
        if (next && m_currentPage < m_maxPage)
            m_currentPage ++;
        
        // If previous has been trigger, make sure it's above 0
        if (!next && m_currentPage > 0)
            m_currentPage --;

        // Update the screen
        m_screen.sprite = m_pages[m_currentPage];

        // Update the showing btns on the page
        ScanBtn();
    }

}
