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
            if (GameManager.IsRankMode)
            {
                _uiManager.AccuracyTextPrecentage.text = Score + "%";
            }
            else
            {
                if (PlayerPoints == null)
                {
                    PlayerPoints = GameObject.Find(GameManager.UserID);
                }
                _uiManager.MessageBoardText("Your scored: " + _userScore);
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
                Rounds++;
            }
        }
    }
    public int Rounds
    {
        get { return _rounds; }
        set { 
            _rounds = value;
            if (_rounds == 5)
            {
                GameEnd();
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
    /// </summary>
    public void FinishMix()
    {
        RoundStart = false;
        _userScore = 0;
        float _fullScore = 0;
        foreach(StripValues strip in Strips)
        {
            switch (strip.StripIndex)
            {
                case 0:
                    {
                        if ((float)CorrectStrip0.Pan == 0.00f && strip.Pan == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip0.Pan == 0.00f || strip.Pan == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Pan / (float)CorrectStrip0.Pan) ;

                        if ((float)CorrectStrip0.Delay == 0.00f && strip.Delay == 0.00f) 
                            _userScore += 10;
                        else if ((float)CorrectStrip0.Delay == 0.00f || strip.Delay == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Delay / (float)CorrectStrip0.Delay) ;

                        if ((float)CorrectStrip0.Reverb == 0.00f && strip.Reverb == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip0.Reverb == 0.00f || strip.Reverb == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Reverb / (float)CorrectStrip0.Reverb) ;

                        if ((float)CorrectStrip0.EQ == 0.00f && strip.EQ == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip0.EQ == 0.00f || strip.EQ == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.EQ / (float)CorrectStrip0.EQ) ;

                        if ((float)CorrectStrip0.Volume == 0.00f && strip.Volume == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip0.Volume == 0.00f || strip.Volume == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Volume / (float)CorrectStrip0.Volume) ;


                        _fullScore += (float)CorrectStrip0.EQ;
                        _fullScore += (float)CorrectStrip0.Reverb;
                        _fullScore += (float)CorrectStrip0.Delay;
                        _fullScore += (float)CorrectStrip0.Pan;
                        _fullScore += (float)CorrectStrip0.Volume;
                    
                    break;
                    }
                case 1:
                    {
                        if ((float)CorrectStrip1.Pan == 0.00f && strip.Pan == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip1.Pan == 0.00f || strip.Pan == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Pan  / (float)CorrectStrip1.Pan) ;

                        if ((float)CorrectStrip1.Delay == 0.00f && strip.Delay == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip1.Delay == 0.00f || strip.Delay == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Delay / (float)CorrectStrip1.Delay) ;

                        if ((float)CorrectStrip1.Reverb == 0.00f && strip.Reverb == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip1.Reverb == 0.00f || strip.Reverb == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Reverb / (float)CorrectStrip1.Reverb) ;

                        if ((float)CorrectStrip1.EQ == 0.00f && strip.EQ == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip1.EQ == 0.00f || strip.EQ == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.EQ / (float)CorrectStrip1.EQ) ;

                        if ((float)CorrectStrip1.Volume == 0.00f && strip.Volume == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip1.Volume == 0.00f || strip.Volume == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Volume / (float)CorrectStrip1.Volume) ;


                        _fullScore += (float)CorrectStrip1.EQ;
                        _fullScore += (float)CorrectStrip1.Reverb;
                        _fullScore += (float)CorrectStrip1.Delay;
                        _fullScore += (float)CorrectStrip1.Pan;
                        _fullScore += (float)CorrectStrip1.Volume;

                        break;
                    }
                case 2:
                    {
                        if ((float)CorrectStrip2.Pan == 0.00f && strip.Pan == 0.00f)
                            _userScore += 10;
                        else if (CorrectStrip2.Pan == 0.00f || strip.Pan == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Pan / (float)CorrectStrip2.Pan) ;

                        if ((float)CorrectStrip2.Delay == 0.00f && strip.Delay == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip2.Delay == 0.00f || strip.Delay == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Delay / (float)CorrectStrip2.Delay) ;

                        if ((float)CorrectStrip2.Reverb == 0.00f && strip.Reverb == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip2.Reverb == 0.00f || strip.Reverb == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Reverb / (float)CorrectStrip2.Reverb) ;

                        if ((float)CorrectStrip2.EQ == 0.00f && strip.EQ == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip2.EQ == 0.00f || strip.EQ == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.EQ / (float)CorrectStrip2.EQ) ;

                        if ((float)CorrectStrip2.Volume == 0.00f && strip.Volume == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip2.Volume == 0.00f || strip.Volume == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Volume / (float)CorrectStrip2.Volume) ;


                        _fullScore += (float)CorrectStrip2.EQ;
                        _fullScore += (float)CorrectStrip2.Reverb;
                        _fullScore += (float)CorrectStrip2.Delay;
                        _fullScore += (float)CorrectStrip2.Pan;
                        _fullScore += (float)CorrectStrip2.Volume;

                        break;
                    }
                case 3:
                    {
                        if ((float)CorrectStrip3.Pan == 0.00f && strip.Pan == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip3.Pan == 0.00f || strip.Pan == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Pan / (float)CorrectStrip3.Pan) ;

                        if ((float)CorrectStrip3.Delay == 0.00f && strip.Delay == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip3.Delay == 0.00f || strip.Delay == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Delay / (float)CorrectStrip3.Delay) ;

                        if ((float)CorrectStrip3.Reverb == 0.00f && strip.Reverb == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip3.Reverb == 0.00f || strip.Reverb == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Reverb / (float)CorrectStrip3.Reverb);

                        if ((float)CorrectStrip3.EQ == 0.00f && strip.EQ == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip3.EQ == 0.00f || strip.EQ == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.EQ / (float)CorrectStrip3.EQ) ;

                        if ((float)CorrectStrip3.Volume == 0.00f && strip.Volume == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip3.Volume == 0.00f || strip.Volume == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Volume / (float)CorrectStrip3.Volume) ;


                        _fullScore += (float)CorrectStrip3.EQ;
                        _fullScore += (float)CorrectStrip3.Reverb;
                        _fullScore += (float)CorrectStrip3.Delay;
                        _fullScore += (float)CorrectStrip3.Pan;
                        _fullScore += (float)CorrectStrip3.Volume;

                        break;
                    }
                case 4:
                    {
                        if ((float)CorrectStrip4.Pan == 0.00f && strip.Pan == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip4.Pan == 0.00f || strip.Pan == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Pan / (float)CorrectStrip4.Pan) ;

                        if ((float)CorrectStrip4.Delay == 0.00f && strip.Delay == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip4.Delay == 0.00f || strip.Delay == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Delay / (float)CorrectStrip4.Delay) ;

                        if ((float)CorrectStrip4.Reverb == 0.00f && strip.Reverb == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip4.Reverb == 0.00f || strip.Reverb == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Reverb / (float)CorrectStrip4.Reverb) ;

                        if ((float)CorrectStrip4.EQ == 0.00f && strip.EQ == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip4.EQ == 0.00f || strip.EQ == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.EQ / (float)CorrectStrip4.EQ) ;

                        if ((float)CorrectStrip4.Volume == 0.00f && strip.Volume == 0.00f)
                            _userScore += 10;
                        else if ((float)CorrectStrip4.Volume == 0.00f || strip.Volume == 0.00f)
                            _userScore += 0;
                        else
                            _userScore += ((int)strip.Volume / (float)CorrectStrip4.Volume) ;


                        _fullScore += (float)CorrectStrip4.EQ;
                        _fullScore += (float)CorrectStrip4.Reverb;
                        _fullScore += (float)CorrectStrip4.Delay;
                        _fullScore += (float)CorrectStrip4.Pan;
                        _fullScore += (float)CorrectStrip4.Volume;

                        break;
                    }
            }
            Debug.Log("After Switch for strip:"+strip.StripIndex+" User Score: " + _userScore + " FullScore: " + _fullScore);
        }
        if (GameManager.IsRankMode)
            Score = (int)((_userScore / _fullScore) * 100);
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
    /// <summary>
    /// Game is End
    /// Will have to do firebase stuff here to give player rewards.
    /// Display winning player
    /// </summary>
    private void GameEnd()
    {
        _uiManager.GameEnd();
    }

   
}
