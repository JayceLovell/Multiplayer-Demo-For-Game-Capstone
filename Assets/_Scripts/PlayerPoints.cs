using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    /// <summary>
    /// text box to display username and points
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI _displayPoints;

    private GameManager _gameManager;

    public float _points;

    public float Points
    {
        get { return _points; }
        set { 
            _points = value;
            _displayPoints.text = _gameManager.UserID + ":" + Points;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _displayPoints = GetComponent<TextMeshProUGUI>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
