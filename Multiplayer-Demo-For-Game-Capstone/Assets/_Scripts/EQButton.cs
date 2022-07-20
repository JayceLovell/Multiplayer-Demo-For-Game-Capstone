using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQButton : MonoBehaviour
{
    public int channelInd;

    /**
     * <summary>
     * Initializes this EQ button
     * </summary>
     * <param name="channelInd"> The index of the channel strip this button is on </param>
     */
    public void Init(int channelInd)
    {
        this.channelInd = channelInd;
    }

    /**
     * <summary>
     * Called whenever this button is pressed
     * </summary>
     */
    //public void OpenEQWindow()
    //{
    //    Debug.Log("opening EQ window for channel " + channelInd);
    //    EQWindowManager.instance.OpenEQWindow(channelInd);
    //    Debug.Log("CHANNEL ID " + channelInd);

    //    //Find the channel strip this button is attached to, and make it the selected channel for the right panel UI manager
    //    var selectedChannel = GetComponentInParent<ChannelStripMetaData>().transform.gameObject;
    //    RightPanelUIManager.Instance.AddToSelectedChannels(selectedChannel);
    //}
}
