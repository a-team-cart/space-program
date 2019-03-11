using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Global Ressources")]
    public float _evaluation = 100f;
    public float _energy = 100f;
    public float _credit = 100f;

    [Header("Ressource Modifiers")]
    public float _defaultModifierValue = 0.5f;
    public float _evaluationModifier;
    public float _energyModifier;
    public float _creditModifier;

    [Header("Global Ressources References")]
    public Text _evaluationRef;
    public Text _energyRef;
    public Text _creditRef;
    public Text _isWorkingRef;
    public Text _isSpendingRef;
    public Text _isRestingRef;
    public Text _gameStatusRef;

    [Header("Global Ressources Booleans")]
    //boolean condition for when to increment
    public bool _isWorking = false;
    public bool _isResting = false;
    public bool _isSpending = false;

    [Header("Game Status")]
    public string _gameStatus = "not determined yet";




    [Header("Task Properties")]
    //Ali's Code
    public int m_tasksCompleted;
    public List<string> completedTasks;


    // Start is called before the first frame update
    void Start()
    {
        //init function to initialize values
        init();
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        debugBehaviour();

        //ressource behaviour
        RessourceBehaviour();

        //winning or losing conditions
        YourAFailure();
        YouBurntOutCuzYouSuck();
        YourStillAFailureButYouDidAnOKJob();
    }

    //debug
    public void debugBehaviour(){
        //input debug
        if(Input.GetKey("space")){
            _isWorking = true;
        }
        else{
            _isWorking = false;
        }

        if(Input.GetKey("e")){
            _isResting = true;
        }
        else{
            _isResting = false;
        }

        if(Input.GetKey("c")){
            _isSpending = true;
        }
        else{
            _isSpending = false;
        }

        //display the value on screen
        _evaluationRef.text = _evaluation.ToString();
        _energyRef.text = _energy.ToString();
        _creditRef.text = _credit.ToString();
        _isWorkingRef.text = _isWorking.ToString();
        _isRestingRef.text = _isResting.ToString();
        _isSpendingRef.text = _isSpending.ToString();
        _gameStatusRef.text = _gameStatus;


    }

    //initializing function
    public void init(){
        //initialize modifier with the default value
        _evaluationModifier = _defaultModifierValue;
        _energyModifier = _defaultModifierValue;
        _creditModifier = _defaultModifierValue;
    }

    //CALCULATING RESSOURCES
    public void RessourceBehaviour(){

        //if your working, increase eval
        if(_isWorking){
            _evaluation += Time.deltaTime * _evaluationModifier;
            _energy -= Time.deltaTime * _energyModifier;
        }

        if(_isResting){
            _energy += Time.deltaTime * _energyModifier;
            _evaluation -= Time.deltaTime * _evaluationModifier;
        }

        if(_isSpending){
            _credit -= Time.deltaTime * _creditModifier;
        }
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
    // Losing and Winning Condition Methods
    // -------------------------------------
    public void YourAFailure(){
        if(_evaluation < 0)
            _gameStatus = "You failed the company";
            // Debug.Log("You failed the company");
    }

    public void YouBurntOutCuzYouSuck(){
        if(_energy < 0)
            _gameStatus = "You Burnt out bro";
            // Debug.Log("You Burnt out bro");
    }

    public void YourStillAFailureButYouDidAnOKJob(){
        if(_evaluation > 500)
            _gameStatus = "Go work at McDonald, It pays better";
            // Debug.Log("Go work at McDonald, It pays better");
    }

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
