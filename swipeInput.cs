//Put this and swipeManager.cs on a game object (doesn't have to be the same game object)
//Works with mouse and touch
//There is also support for diagonal directions, but I won't list them all because you get the idea

using UnityEngine;

public class swipeInput : MonoBehaviour
{
    void Update()
    {
        if(swipeManager.direction == Swipes.Down)
        {
            Debug.Log("Down");
        }
        else if (swipeManager.direction == Swipes.Up)
        {
            Debug.Log("Up");
        }
        else if (swipeManager.direction == Swipes.Left)
        {
            Debug.Log("Left");
        }
        else if (swipeManager.direction == Swipes.Right)
        {
            Debug.Log("Right");
        }
    }
}
