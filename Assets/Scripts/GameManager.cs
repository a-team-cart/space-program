using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int m_tasksCompleted;
    public List<string> completedTasks;

    //private float waterTimer = 30.0f;
    //private float foodTimer = 15.0f;
    private float oxygenTimer = 5.0f;

    //public bool needWater = false;
    //public bool needFood = false;
    public bool needOxygen = false;
    public bool noPower = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //waterTimer -= Time.deltaTime;
        //foodTimer -= Time.deltaTime;
        if (noPower)
        {
            oxygenTimer -= Time.deltaTime;

            if (oxygenTimer < 0)
            {
                NeedOxygen();
            }
        }
        //if (waterTimer < 0)
        //{
        //    NeedWater();
        //}
        //if (foodTimer < 0)
        //{
        //    NeedFood();
        //}
    }

    // -------------------------------------
    // Score & Task Methods
    // -------------------------------------
    public void TaskCompleted(string taskCompleted)
    {
        m_tasksCompleted++;
        completedTasks.Add(taskCompleted);
    }
    
    public void CompileTasksCompleted()
    {
        //Print out completed tasks in a list for the report

    }

    // -------------------------------------
    // Player Condition Methods
    // -------------------------------------

    public void NeedOxygen()
    {
        this.needOxygen = true;
    }

    //public void NeedWater()
    //{
    //    this.needWater = true;
    //}

    //public void NeedFood()
    //{
    //    this.needFood = true;
    //}

    // -------------------------------------
    // Application Methods
    // -------------------------------------
    //Quit the application
    private void Quit()
    {
        Application.Quit();
    }

    //Restart application
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
