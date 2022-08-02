using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// This script is for any UI navigation
/// WARNING THIS IS STILL UNDER CONSTRUCTION NOT FINAL SCRIPT
/// </summary>
public class UiManager : MonoBehaviour
{
    public bool IsActiveMenu;

    private MemoryFeudManager _memoryFeudManager;
    private MusicPlayer _musicPlayer;
    private GameManager _gameManager;
    private NetworkManager networkmanager;
    private bool isSongPlaying;
    public Animator PopUpMessageBoard;
    public Animator SubmitAnimator;
    public GameObject DisplaySong;
    public GameObject Reference;
    public GameObject MySong;
    public GameObject Clock;
    public GameObject SubmitButton;
    public Text AccuracyTextPrecentage;
    public Text PopUpMessageBoardText;
    
    public bool IsSongPlaying
    {
        get { return isSongPlaying; }
        set { 
            isSongPlaying = value;
            if (isSongPlaying)
            {
                Reference.SetActive(true);
                MySong.SetActive(false);
                DisplaySong.GetComponent<Text>().text = _musicPlayer.SongName;
                DisplaySong.GetComponent<Text>().alignment = TextAnchor.LowerLeft;
                Clock.GetComponent<Clock>().AmoutOfTime = 30;
            }
            else
            {
                Reference.SetActive(false);
                MySong.SetActive(true);
                DisplaySong.GetComponent<Text>().text = _musicPlayer.SongName;
                DisplaySong.GetComponent<Text>().alignment = TextAnchor.LowerLeft;
                _memoryFeudManager.RoundStart = true;
                Clock.GetComponent<Clock>().AmoutOfTime = 60f;
                BringUpPopUps();
            }
        }
    }
    /// <summary>
    /// is Called before Start
    /// </summary>
    void Awake()
    {
        _memoryFeudManager = GameObject.Find("MemoryFeudManager").GetComponent<MemoryFeudManager>();
        _musicPlayer = GameObject.Find("Music Player").GetComponent<MusicPlayer>();
        networkmanager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    /// <summary>
    /// Starts game
    /// </summary>
    public void Ready()
    {
        _memoryFeudManager.GameStart();
        GameObject.Find("BtnReady").GetComponent<Button>().interactable = false;
        MessageBoardText("listen to song carefully");
    }
    /// <summary>
    /// Gathers UI that is instantiated with prefab of mixing board
    /// </summary>
    public void GetSpawnedUI()
    {
        GameObject.Find("BtnReady").GetComponent<Button>().onClick.AddListener(GameObject.Find("UI Manager").GetComponent<UiManager>().Ready);
        SubmitButton = GameObject.Find("BtnSubmit");
        SubmitButton.GetComponent<Button>().interactable = false;
        SubmitButton.GetComponent<Button>().onClick.AddListener(_memoryFeudManager.FinishMix);
        SubmitAnimator=SubmitButton.transform.GetChild(0).gameObject.GetComponent<Animator>();
        if (_gameManager.IsRankMode)
        {
            AccuracyTextPrecentage = GameObject.Find("AccuracyPrecentage").GetComponent<Text>();
        }
    }
    /// <summary>
    /// Bring up popups to tell player
    /// </summary>
    public void BringUpPopUps()
    {
        RoundStart();
        MessageBoardText("Now Mix");
        SubmitAnimator.SetBool("visible", true);
        PopUpMessageBoard.SetBool("visible", true);
        StartCoroutine(WaitForSeconds(10, BringDownPopUps));
    }
    /// <summary>
    /// Brings down Popups after 10 seconds
    /// </summary>
    public void BringDownPopUps()
    {
        PopUpMessageBoard.SetBool("visible", false);
        SubmitAnimator.SetBool("visible", false);
    }
    /// <summary>
    /// Message to Display to user
    /// </summary>
    /// <param Message to Display="Message"></param>
    public void MessageBoardText(string Message)
    {
        PopUpMessageBoard.SetBool("visible", true);
        PopUpMessageBoardText.text = Message;
        StartCoroutine(WaitForSeconds(5, BringDownPopUps));
    }
    /// <summary>
    /// Do round start Ui stuff
    /// </summary>
    public void RoundStart()
    {
        SubmitButton.GetComponent<Button>().interactable = true;
    }
    /// <summary>
    /// DO round end UI stuff
    /// </summary>
    public void RoundEnd()
    {
        MySong.SetActive(false);
        DisplaySong.GetComponent<Text>().text = "Song Name";
        DisplaySong.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        SubmitButton.GetComponent<Button>().interactable = false;
        GameObject.Find("BtnReady").GetComponent<Button>().interactable = true;
    }
    /// <summary>
    /// TODO
    /// Change this to work with firebase and go back to gameScene Or Menu
    /// </summary>
    public void Exit()
    {
        if (_gameManager.Status == "Hosting")
        {
            networkmanager.StopHost();
            Debug.Log("Ending Host");
        }
        else
        {
            networkmanager.StopClient();
            Debug.Log("Ending Client");
        }
    }
    public void DROP_DOWN_CLICK(Animator anim)
    {
        IsActiveMenu = !IsActiveMenu;
        ANIMATION_STATE(anim, "IsActive", IsActiveMenu);
    }
    public static void ANIMATION_STATE(Animator anim, string parameterName, bool state)
    {
        anim.SetBool(parameterName, state);
    }

    private IEnumerator WaitForSeconds(float Seconds,Action MethodName)
    {
        yield return new WaitForSeconds(Seconds);
        MethodName();
    }
}
