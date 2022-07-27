using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFeudManager : MonoBehaviour
{
    private int _score;
    private bool _roundStart;
    private int _rounds;

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
    public bool RoundStart
    {
        get { return _roundStart; }
        set { 
            _roundStart = value;
            if (_roundStart)
            {
                _rounds++;
                _uiManager.Clock.GetComponent<Clock>().AmoutOfTime = 60f;
                _uiManager.BringUpPopUps();
            }
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
    public UiManager _uiManager;

    //Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hostAddress = GameManager.HostAddress;
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
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
        _uiManager.GetComponent<UiManager>().GetSpawnedUI();
        RoundStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundStart)
        {
            if (_uiManager.GetComponent<UiManager>().Clock.GetComponent<Clock>().StartTimer)
            {
                // player does their mixes
            }
            else
            {
                FinishMix();
            }
        }
    }
    /// <summary>
    /// Player finishes early and submits their mix
    /// or
    /// time runs out
    /// will do calculations of accuracy
    /// </summary>
    public void FinishMix()
    {
        RoundStart = false;
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
