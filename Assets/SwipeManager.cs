//	The MIT License (MIT)
//	
//	Copyright (c) 2015 neervfx
//		
//	Permission is hereby granted, free of charge, to any person obtaining a copy
//	of this software and associated documentation files (the "Software"), to deal
//	in the Software without restriction, including without limitation the rights
//	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//	copies of the Software, and to permit persons to whom the Software is
//	furnished to do so, subject to the following conditions:
//		
//	The above copyright notice and this permission notice shall be included in all
//	copies or substantial portions of the Software.
//		
//	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//	SOFTWARE.

using UnityEngine;

public enum Swipes { None, Up, Down, Left, TopLeft, BottomLeft, Right, TopRight,  BottomRight};

public class SwipeManager : MonoBehaviour
{
    public float minSwipeLength = 200f;
  
    private Vector2 fingerStart;
    private Vector2 fingerEnd;

    public static Swipes direction;
	public static float angle;
	public static Vector2 strength;

	public static bool debugMode = false;

    void Update ()
    {
        SwipeDetection();
    }

    public void SwipeDetection ()
    {
        if (Input.GetMouseButtonDown(0)) {
            fingerStart = Input.mousePosition;
            fingerEnd  = Input.mousePosition;
        }

        if(Input.GetMouseButton(0)) {
            fingerEnd = Input.mousePosition;

			strength = new Vector2 (fingerEnd.x - fingerStart.x, fingerEnd.y - fingerStart.y);

            // Make sure it was a legit swipe, not a tap
			if (strength.magnitude < minSwipeLength) {
                direction = Swipes.None;
                return;
            }

			angle = (Mathf.Atan2(strength.y, strength.x) / (Mathf.PI));
			if (debugMode) Debug.Log(angle);
            // Swipe up
            if (angle>0.375f && angle<0.625f) {
                direction = Swipes.Up;
				if (debugMode) Debug.Log ("Up");
                // Swipe down
            } else if (angle<-0.375f && angle>-0.625f) {
                direction = Swipes.Down;
				if (debugMode) Debug.Log ("Down");
                // Swipe left
            } else if (angle<-0.875f || angle>0.875f) {
                direction = Swipes.Left;
				if (debugMode) Debug.Log ("Left");
                // Swipe right
            } else if (angle>-0.125f && angle<0.125f) {
                direction = Swipes.Right;
				if (debugMode) Debug.Log ("Right");
            }
            else if(angle>0.125f && angle<0.375f){
                direction = Swipes.TopRight;
				if (debugMode) Debug.Log ("top right");
            }
            else if(angle>0.625f && angle<0.875f){
                direction = Swipes.TopLeft;
				if (debugMode) Debug.Log ("top left");
            }
            else if(angle<-0.125f && angle>-0.375f){
                direction = Swipes.BottomRight;
				if (debugMode) Debug.Log ("bottom right");
            }
            else if(angle<-0.625f && angle>-0.875f){
                direction = Swipes.BottomLeft;
				if (debugMode) Debug.Log ("bottom left");
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            direction = Swipes.None;  
        }
    }
}
