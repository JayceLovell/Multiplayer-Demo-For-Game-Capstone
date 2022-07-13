using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyBattleManager : MonoBehaviour
{
    private int _score;

    [SerializeField]
    private string hostAddress;

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
    public GameObject MusicPlayer;

    [Header("Game Parameters")]                                             // Number of channel strips to spawn
    protected const int NumberOfRounds = 3;                                               // Number of rounds they play
    protected int currentRound;
    protected float roundBeingPlayed;
    protected float roundAccuracy;                                                        // Accuracy for current round
    protected List<float> userAccuracies;                                                 // List of user accuracies

    //Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hostAddress = GameManager.HostAddress;
        PlayerPoints = GameObject.Find(GameManager.UserID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Starts game
    /// </summary>
    public void GameStart()
    {
        PlaySound();
    }
    private void PlaySound()
    {
        MusicPlayer.GetComponent<AccuracyBattleMusicPlayer>().Play();
    }
}
