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

public class swipeManager : MonoBehaviour
{
    public float minSwipeLength = 200f;
    Vector2 currentSwipe;

    private Vector2 fingerStart;
    private Vector2 fingerEnd;

    public static Swipes direction;

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

            currentSwipe = new Vector2 (fingerEnd.x - fingerStart.x, fingerEnd.y - fingerStart.y);

            // Make sure it was a legit swipe, not a tap
            if (currentSwipe.magnitude < minSwipeLength) {
                direction = Swipes.None;
                return;
            }

            float angle = (Mathf.Atan2(currentSwipe.y, currentSwipe.x) / (Mathf.PI));
            Debug.Log(angle);
            // Swipe up
            if (angle>0.375f && angle<0.625f) {
                direction = Swipes.Up;
                Debug.Log ("Up");
                // Swipe down
            } else if (angle<-0.375f && angle>-0.625f) {
                direction = Swipes.Down;
                Debug.Log ("Down");
                // Swipe left
            } else if (angle<-0.875f || angle>0.875f) {
                direction = Swipes.Left;
                Debug.Log ("Left");
                // Swipe right
            } else if (angle>-0.125f && angle<0.125f) {
                direction = Swipes.Right;
                Debug.Log ("Right");
            }
            else if(angle>0.125f && angle<0.375f){
                direction = Swipes.TopRight;
                Debug.Log ("top right");
            }
            else if(angle>0.625f && angle<0.875f){
                direction = Swipes.TopLeft;
                Debug.Log ("top left");
            }
            else if(angle<-0.125f && angle>-0.375f){
                direction = Swipes.BottomRight;
                Debug.Log ("bottom right");
            }
            else if(angle<-0.625f && angle>-0.875f){
                direction = Swipes.BottomLeft;
                Debug.Log ("bottom left");
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            direction = Swipes.None;  
        }
    }
}
