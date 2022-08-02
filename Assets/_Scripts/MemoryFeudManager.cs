using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFeudManager : MonoBehaviour
{
    private int _score;
    private bool _roundStart;
    private int _rounds;
    private float _userScore;

    [SerializeField]
    private string hostAddress;
    /// <summary>
    /// Saving correct values for now should be replaced with real accuracy from sonically
    /// </summary>
    public enum CorrectStrip0
    {
        Pan = 50,
        Delay = 0,
        Reverb = 0,
        EQ = 0,
        Volume = 50
    }
    public enum CorrectStrip1
    {
        Pan = 50,
        Delay = 0,
        Reverb = 0,
        EQ = 0,
        Volume = 50
    }
    public enum CorrectStrip2
    {
        Pan = 50,
        Delay = 0,
        Reverb = 0,
        EQ = 0,
        Volume = 50
    }
    public enum CorrectStrip3
    {
        Pan = 50,
        Delay = 0,
        Reverb = 0,
        EQ = 0,
        Volume = 50
    }
    public enum CorrectStrip4
    {
        Pan = 50,
        Delay = 0,
        Reverb = 0,
        EQ = 0,
        Volume = 50
    }
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log(GameManager.IsRankMode);
            if (GameManager.IsRankMode)
            {
                _uiManager.AccuracyTextPrecentage.text = Score + " %";
            }
            {
                if (PlayerPoints == null)
                {
                    PlayerPoints = GameObject.Find(GameManager.UserID);
                }
                _uiManager.MessageBoardText("Your scored: " + (int)_userScore);
                PlayerPoints.GetComponent<PlayerPoints>().Points = value;
            }
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
    /// TODO Check my math @Jelani
    /// </summary>
    public void FinishMix()
    {
        RoundStart = false;
        _userScore = 0;
        int _fullScore = 0;
        foreach(StripValues strip in Strips)
        {
            switch (strip.StripIndex)
            {
                case 0:
                    {
                        if ((int)CorrectStrip0.Pan == 0 && strip.Pan == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip0.Pan == 0 || strip.Pan == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Pan * 10 / (int)CorrectStrip0.Pan) * 100;

                        if ((int)CorrectStrip0.Delay == 0 && strip.Delay == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip0.Delay == 0 || strip.Delay == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Delay * 10 / (int)CorrectStrip0.Delay) * 100;

                        if ((int)CorrectStrip0.Reverb == 0 && strip.Reverb == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip0.Reverb == 0 || strip.Reverb == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Reverb * 10 / (int)CorrectStrip0.Reverb) * 100;

                        if ((int)CorrectStrip0.EQ == 0 && strip.EQ == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip0.EQ == 0 || strip.EQ == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.EQ * 10 / (int)CorrectStrip0.EQ) * 100;

                        if ((int)CorrectStrip0.Volume == 0 && strip.Volume == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip0.Volume == 0 || strip.Volume == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Volume * 10 / (int)CorrectStrip0.Volume) * 100;


                        _fullScore += (int)CorrectStrip0.EQ;
                        _fullScore += (int)CorrectStrip0.Reverb;
                        _fullScore += (int)CorrectStrip0.Delay;
                        _fullScore += (int)CorrectStrip0.Pan;
                        _fullScore += (int)CorrectStrip0.Volume;
                    
                    break;
                    }
                case 1:
                    {
                        if ((int)CorrectStrip1.Pan == 0 && strip.Pan == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip1.Pan == 0 || strip.Pan == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Pan * 100 / (int)CorrectStrip1.Pan) * 100;

                        if ((int)CorrectStrip1.Delay == 0 && strip.Delay == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip1.Delay == 0 || strip.Delay == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Delay * 100 / (int)CorrectStrip1.Delay) * 100;

                        if ((int)CorrectStrip1.Reverb == 0 && strip.Reverb == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip1.Reverb == 0 || strip.Reverb == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Reverb * 100 / (int)CorrectStrip1.Reverb) * 100;

                        if ((int)CorrectStrip1.EQ == 0 && strip.EQ == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip1.EQ == 0 || strip.EQ == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.EQ * 100 / (int)CorrectStrip1.EQ) * 100;

                        if ((int)CorrectStrip1.Volume == 0 && strip.Volume == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip1.Volume == 0 || strip.Volume == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Volume * 100 / (int)CorrectStrip1.Volume) * 100;


                        _fullScore += (int)CorrectStrip1.EQ;
                        _fullScore += (int)CorrectStrip1.Reverb;
                        _fullScore += (int)CorrectStrip1.Delay;
                        _fullScore += (int)CorrectStrip1.Pan;
                        _fullScore += (int)CorrectStrip1.Volume;

                        break;
                    }
                case 2:
                    {
                        if ((int)CorrectStrip2.Pan == 0 && strip.Pan == 0)
                            _userScore += 100;
                        else if (CorrectStrip2.Pan == 0 || strip.Pan == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Pan * 100 / (int)CorrectStrip2.Pan) * 100;

                        if ((int)CorrectStrip2.Delay == 0 && strip.Delay == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip2.Delay == 0 || strip.Delay == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Delay * 100 / (int)CorrectStrip2.Delay) * 100;

                        if ((int)CorrectStrip2.Reverb == 0 && strip.Reverb == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip2.Reverb == 0 || strip.Reverb == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Reverb * 100 / (int)CorrectStrip2.Reverb) * 100;

                        if ((int)CorrectStrip2.EQ == 0 && strip.EQ == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip2.EQ == 0 || strip.EQ == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.EQ * 100 / (int)CorrectStrip2.EQ) * 100;

                        if ((int)CorrectStrip2.Volume == 0 && strip.Volume == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip2.Volume == 0 || strip.Volume == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Volume * 100 / (int)CorrectStrip2.Volume) * 100;


                        _fullScore += (int)CorrectStrip2.EQ;
                        _fullScore += (int)CorrectStrip2.Reverb;
                        _fullScore += (int)CorrectStrip2.Delay;
                        _fullScore += (int)CorrectStrip2.Pan;
                        _fullScore += (int)CorrectStrip2.Volume;

                        break;
                    }
                case 3:
                    {
                        if ((int)CorrectStrip3.Pan == 0 && strip.Pan == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip3.Pan == 0 || strip.Pan == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Pan * 100 / (int)CorrectStrip3.Pan) * 100;

                        if ((int)CorrectStrip3.Delay == 0 && strip.Delay == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip3.Delay == 0 || strip.Delay == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Delay * 100 / (int)CorrectStrip3.Delay) * 100;

                        if ((int)CorrectStrip3.Reverb == 0 && strip.Reverb == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip3.Reverb == 0 || strip.Reverb == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Reverb * 100 / (int)CorrectStrip3.Reverb) * 100;

                        if ((int)CorrectStrip3.EQ == 0 && strip.EQ == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip3.EQ == 0 || strip.EQ == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.EQ * 100 / (int)CorrectStrip3.EQ) * 100;

                        if ((int)CorrectStrip3.Volume == 0 && strip.Volume == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip3.Volume == 0 || strip.Volume == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Volume * 100 / (int)CorrectStrip3.Volume) * 100;


                        _fullScore += (int)CorrectStrip3.EQ;
                        _fullScore += (int)CorrectStrip3.Reverb;
                        _fullScore += (int)CorrectStrip3.Delay;
                        _fullScore += (int)CorrectStrip3.Pan;
                        _fullScore += (int)CorrectStrip3.Volume;

                        break;
                    }
                case 4:
                    {
                        if ((int)CorrectStrip4.Pan == 0 && strip.Pan == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip4.Pan == 0 || strip.Pan == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Pan * 100 / (int)CorrectStrip4.Pan) * 100;

                        if ((int)CorrectStrip4.Delay == 0 && strip.Delay == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip4.Delay == 0 || strip.Delay == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Delay * 100 / (int)CorrectStrip4.Delay) * 100;

                        if ((int)CorrectStrip4.Reverb == 0 && strip.Reverb == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip4.Reverb == 0 || strip.Reverb == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Reverb * 100 / (int)CorrectStrip4.Reverb) * 100;

                        if ((int)CorrectStrip4.EQ == 0 && strip.EQ == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip4.EQ == 0 || strip.EQ == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.EQ * 100 / (int)CorrectStrip4.EQ) * 100;

                        if ((int)CorrectStrip4.Volume == 0 && strip.Volume == 0)
                            _userScore += 100;
                        else if ((int)CorrectStrip4.Volume == 0 || strip.Volume == 0)
                            _userScore += 0;
                        else
                            _userScore += (strip.Volume * 100 / (int)CorrectStrip4.Volume) * 100;


                        _fullScore += (int)CorrectStrip4.EQ;
                        _fullScore += (int)CorrectStrip4.Reverb;
                        _fullScore += (int)CorrectStrip4.Delay;
                        _fullScore += (int)CorrectStrip4.Pan;
                        _fullScore += (int)CorrectStrip4.Volume;

                        break;
                    }
            }
            Debug.Log("After Switch User Score: " + (int)_userScore + " FullScore: " + _fullScore);
        }
        if (GameManager.IsRankMode)
            Score = ((int)_userScore / _fullScore) * 100;
        else
            Score += (int)_userScore;
        
        _uiManager.RoundEnd();
        RoundStart = false;
    }
    /// <summary>
    /// Starts game
    /// </summary>
    public void GameStart()
    {
        //Get the mixing board strips
        GameObject[] Stripboards = GameObject.FindGameObjectsWithTag("Strip");
        foreach (GameObject board in Stripboards)
        {
            Strips.Add(board.GetComponent<StripValues>());
        }
        PlaySound();
    }
    private void PlaySound()
    { 
        MusicPlayer.GetComponent<MusicPlayer>().Play();
    }
}
