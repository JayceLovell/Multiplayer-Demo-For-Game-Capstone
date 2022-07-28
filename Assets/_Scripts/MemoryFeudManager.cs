using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFeudManager : MonoBehaviour
{
    private float _score;
    private bool _roundStart;
    private int _rounds;

    [SerializeField]
    private string hostAddress;
    public float Score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Player Points = "+ _score);
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

    public List<StripValues> Strips=new List<StripValues>();

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

        //Get the mixing board strips
        GameObject[] Stripboards = GameObject.FindGameObjectsWithTag("Strip");
        foreach(GameObject board in Stripboards)
        {
            Strips.Add(board.GetComponent<StripValues>());
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
                //Gets called if player ran out of time and didn't hit submit
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
        float tempScore = 0;
        foreach(StripValues strip in Strips)
        {
            tempScore += strip.Pan;
            tempScore += strip.Delay;
            tempScore += strip.Reverb;
            tempScore += strip.EQ;
            tempScore += strip.Volume;
        }

        Score += (int)(tempScore*1000);
        RoundStart = false;
        _uiManager.MessageBoardText("Your scored: " + Score);
        _uiManager.RoundEnd();
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
