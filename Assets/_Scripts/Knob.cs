using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public GameObject knob; //drag and drop the knob asset (the part that turns)

    protected float min = 0;
    protected float max = 1;
    protected float range = 1;

    [SerializeField]
    protected float currPosition = 0; //keeps track of the knob's current position
    protected float unroundedPos = 0; //keeps track of the exact value that the user has positioned the knob before any rounding
    public int numNotches = 100; //the number of notches (depends on the tier usually)

    /**
    * <summary>
    * Public getter method that returns the position of this knob
    * </summary>
    */
    public float GetCurrPos()
    {
        return currPosition;
    }

    /**
    * <summary>
    * Helper function to convert currPosition to a rotation in degrees
    * </summary>
    */
    protected float findRotation()
    {
        //Replace with float rotRange = GameConstants.KNOB_RANGE_IN_DEGREES; from  the GameConstraints
        float rotRange = 5;

        //calculate what roation the knob should be at to reflect its current setting
        float distanceFromLowestRotation = currPosition * rotRange;
        float lowestRotation = rotRange / 2f;
        float rotation = lowestRotation - distanceFromLowestRotation;
        return rotation;
    }

    /**
    * <summary>
    * Determiines rotation based on currPosition and rotates the knob accordingly
    * </summary>
    */
    public void RotateKnob()
    {
        //find out the current rotation around the Z axis
        float rotZ = findRotation();
        knob.transform.eulerAngles = new Vector3(
            knob.transform.eulerAngles.x,
            knob.transform.eulerAngles.y,
            rotZ
        );
    }

    /**
    * <summary>
    * Sets the knob's position to the desired value and rotates the knob asset
    * </summary>
    */
    public virtual void SetPos(float position)
    {
        //update the current position of this knob
        currPosition = position;
        RotateKnob();
    }
    /**
    * <summary>
    * Rotates the knob to the closest notch to the given position
    * </summary>
    */
    public void SetRoundedPos(float position)
    {
        //if there are 1 or less notches on the knob there's a problem
        if (numNotches <= 1)
        {
            Debug.Log("Tried to round knob to a notch when there were 1 or less notches");
            return;
        }

        //update the unrounded position variable
        unroundedPos = position;

        //keep the position within the knob's range
        if (position > 1f) position = 1f;
        else if (position < 0f) position = 0f;

        //calculate the increment between each notch
        float notchInc = range / (numNotches - 1);

        //round to the position of the nearest notch
        float roundedPos = Mathf.Round(position / notchInc) * notchInc;

        SetPos(roundedPos);
    }
    /**
    * <summary>
    * Usually called by the DragKnob script. Handles adjustments to the knob
    * by some delta value.
    * </summary>
    */
    public void DragKnob(float dragAmount)
    {
        float newPosition = unroundedPos + dragAmount;
        SetRoundedPos(newPosition);
    }
}
