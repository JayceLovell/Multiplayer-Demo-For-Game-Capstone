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
    /// <summary>
    /// Saving correct values for now should be replaced with real accuracy from sonically
    /// </summary>
    public enum Correct
    {
        Pan = 50,
        Delay = 50,
        Reverb = 50,
        EQ = 50,
        Volume = 50
    }
    public float Score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (GameManager.IsRankMode)
            {

            }
            {
                if (PlayerPoints == null)
                {
                    PlayerPoints = GameObject.Find(GameManager.UserID);
                }
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
        float tempScore = 0;
        foreach(StripValues strip in Strips)
        {
            Debug.Log("Pan: "+strip.Pan);
            Debug.Log("Delay: " + strip.Delay);
            Debug.Log("Reverb: " + strip.Reverb);
            Debug.Log("EQ: " + strip.EQ);
            Debug.Log("Volume: " + strip.Volume);

            tempScore += (strip.Pan/(float)Correct.Pan)*100;
            Debug.Log("Tempscore: " + tempScore);
            tempScore += (strip.Delay / (float)Correct.Delay)*100;
            Debug.Log("Tempscore: " + tempScore);
            tempScore += (strip.Reverb / (float)Correct.Reverb)*100;
            Debug.Log("Tempscore: " + tempScore);
            tempScore += (strip.EQ / (float)Correct.EQ)*100;
            Debug.Log("Tempscore: " + tempScore);
            tempScore += ((strip.Volume*100) / (float)Correct.Volume)*100;
            Debug.Log("Tempscore: " + tempScore);
        }
        Score += (int)tempScore;
        _uiManager.MessageBoardText("Your scored: " + Score);
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
