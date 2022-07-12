using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLeaderboardManager : MonoBehaviour
{
    public List<GameObject> Children = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            Children.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RefreshBoard()
    {
        Children.Clear();
        foreach (Transform child in this.transform)
        {
            Children.Add(child.gameObject);
        }
    }
    /// <summary>
    /// TODO #2925127468
    /// rearrange the boarderboard based on the player points
    /// </summary>
    private void LeaderBoardCheck()
    {
        //to get what points the player have
        //Children[0].GetComponent<PlayerPoints>().Points;

        //To set the poisition of the player points object
        Children[0].transform.SetSiblingIndex(0);
    }
}
