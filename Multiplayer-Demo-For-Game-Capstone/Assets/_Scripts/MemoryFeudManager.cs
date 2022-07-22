using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFeudManager : MonoBehaviour
{
    private int _score;
    [SerializeField]
    private string hostAddress;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (PlayerPoints == null)
            {
                PlayerPoints = GameObject.Find(GameManager.UserID);
            }
            PlayerPoints.GetComponent<PlayerPoints>().Points = value;
        }
    }
    /// <summary>
    /// Board for 1v1
    /// </summary>
    public GameObject RankedLayout;
    /// <summary>
    /// Board for 5 player mode
    /// </summary>
    public GameObject FivePlayerLayout;
    public GameObject Board;
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
        if (GameManager.IsRankMode)
        {
            Board=Instantiate(RankedLayout, GameObject.Find("Canvas").transform);
            Board.transform.SetAsFirstSibling();
        }
        else
        {
            Board=Instantiate(FivePlayerLayout, GameObject.Find("Canvas").transform);
            Board.transform.SetAsFirstSibling();
        }
        GameObject.Find("BtnReady").GetComponent<Button>().onClick.AddListener(GameObject.Find("UI Manager").GetComponent<UiManager>().Ready);
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
        MusicPlayer.GetComponent<MusicPlayer>().Play();
    }
}
