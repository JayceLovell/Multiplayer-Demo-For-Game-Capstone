using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyBattle : MonoBehaviour
{
    private int _score;

    public int Score
    {
        get { return _score; }
        set { 
            _score = value;
            if (PlayerPoints == null)
            {
                PlayerPoints = GameObject.Find(GameManager.UserID);
            }
            PlayerPoints.GetComponent<PlayerPoints>().Points = value;
        }
    }
    public GameManager GameManager;
    [Header("Game Objects")]
    public GameObject PlayerPoints;
    public GameObject faderHandle;
    public GameObject faderTrack;
    public GameObject levelMeter;
    public GameObject levelNotches;
    public GameObject solobutton;
    public GameObject volumePanel;
    public GameObject instramentLabel;
    public GameObject leftPanel;
    public GameObject mixingBoardPanel;
    public GameObject submitButtonObject;
    public GameObject Background;
    public GameObject mixerContainer;                                                   
    public GameObject roundsManager;                                                     
    public Text accuracyReadOut;
    public GameObject faderPrefab;                                             
    public Sprite faderOutline;                                                
    protected GameObject[] userFaders, correctFaderHandles;                    
    protected int numberOfChannelStrips;

    [Header("Clock Variables")]
    public Text timeText;
    public float timeRemaining;
    protected bool timerIsRunning;
    protected bool paused = false;

    //[Header("Game Parameters")]
    public int numberOfChannelStripsWanted = 5;                                               // Number of channel strips to spawn
    protected const int NumberOfRounds = 3;                                               // Number of rounds they play
    protected int currentRound;
    protected float roundBeingPlayed;
    protected float roundAccuracy;                                                        // Accuracy for current round
    protected List<float> userAccuracies;                                                 // List of user accuracies
    protected string[] mode = { "EASY MODE", "NORMAL MODE", "HARD MODE","Ranked" };

    // Start is called before the first frame update                           
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        PlayerPoints = GameObject.Find(GameManager.UserID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
