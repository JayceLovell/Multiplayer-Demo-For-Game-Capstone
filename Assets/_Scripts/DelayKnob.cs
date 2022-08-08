using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayKnob : Knob
{
    public GameObject notches;

    string mixerDelay; //the name of the delay parameter this knob controls
    string mixerWet; //the name of the wet parameter this knob turns on and off

    private bool attached = false;

    public override void SetPos(float position)
    {
        base.SetPos(position);
        LightNotch();
        if (attached) setDelay();
    }
    public void LightNotch()
    {
        float maskRotation = findRotation();
        //fill in soon with code to light up the selected notch
    }

    private int findNotch()
    {
        //edge case when knob is maxed out
        if (currPosition == range) return numNotches - 1;

        //distance between each notch
        float knobInc = range / numNotches;

        //find out the index of the selected notch
        return (int)Mathf.Floor(currPosition / knobInc);
    }

    private void attachMixerDelay(string mixerParam)
    {
        mixerDelay = mixerParam;
    }
    private void attachMixerWet(string mixerParam)
    {
        mixerWet = mixerParam;
    }
    public void AttachUserMixerGroup(int groupIndex)
    {
        attachMixerDelay("UserDelay " + groupIndex);
        attachMixerWet("UserDelayWet " + groupIndex);
        attached = true;
    }

    private void setDelay()
    {
        //find out the index of the selected notch
        int presetNumber = findNotch();
        Debug.Log("--------------------------- NOTCH + " + presetNumber);


    }
}
