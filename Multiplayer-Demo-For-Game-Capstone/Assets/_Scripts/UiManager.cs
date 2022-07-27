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

    private MemoryFeudManager _accuacyBattleManager;
    private MusicPlayer _musicPlayer;
    private GameManager _gameManager;
    private NetworkManager networkmanager;
    private bool isSongPlaying;

    public GameObject DisplaySong;
    public GameObject Reference;
    public GameObject MySong;
    public GameObject Clock;
    public GameObject SubmitButton;
    public GameObject PopUpMessageBoard;
    public Text PopUpMessageBoardText;

    public bool IsSongPlaying
    {
        get { return isSongPlaying; }
        set { 
            isSongPlaying = value;
            if (isSongPlaying)
            {
                Reference.SetActive(true);
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
            }
        }
    }
    /// <summary>
    /// is Called before Start
    /// </summary>
    void Awake()
    {
        _accuacyBattleManager = GameObject.Find("MemoryFeudManager").GetComponent<MemoryFeudManager>();
        _musicPlayer = GameObject.Find("Music Player").GetComponent<MusicPlayer>();
        networkmanager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    /// <summary>
    /// Starts game
    /// </summary>
    public void Ready()
    {
        _accuacyBattleManager.GameStart();
        GameObject.Find("BtnReady").GetComponent<Button>().interactable = false;
    }
    /// <summary>
    /// Gathers UI that is instantiated with prefab of mixing board
    /// </summary>
    public void GetSpawnedUI()
    {
        GameObject.Find("BtnReady").GetComponent<Button>().onClick.AddListener(GameObject.Find("UI Manager").GetComponent<UiManager>().Ready);
        SubmitButton = GameObject.Find("BtnSubmit");
        SubmitButton.GetComponent<Button>().interactable = false;
        SubmitButton.GetComponent<Button>().onClick.AddListener(_accuacyBattleManager.FinishMix);
    }
    /// <summary>
    /// Bring up popups to tell player
    /// TODO @Jelani Animation for smooth effect
    /// </summary>
    public void BringUpPopUps()
    {
        SubmitButton.GetComponent<Button>().interactable = true;
        //Using set active until animation is implementated
        SubmitButton.transform.GetChild(0).gameObject.SetActive(true);

        StartCoroutine(WaitForSeconds(10, BringDownPopUps));
    }
    /// <summary>
    /// Brings down Popups after 10 seconds
    /// @TODO @Jelani u know what to do 
    /// </summary>
    public void BringDownPopUps()
    {
        //Using set active until animation is implementated
        SubmitButton.transform.GetChild(0).gameObject.SetActive(false);
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
