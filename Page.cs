using System;
using GorillaStats;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GorillaStopWatch
{
    public class Page : IGorillaStatsPage
    {
        static float elapsedTime = 0f;
        static bool isRunning = false;
        private bool leftWasPressed;
        private bool rightWasPressed;
        
        public string PageName => "Gorilla StopWatch";
        
        public string GetPageText()
        {
            bool leftPressed = ControllerInputPoller.instance.leftControllerPrimaryButton;
            bool rightPressed = ControllerInputPoller.instance.rightControllerPrimaryButton;
            
            if (rightPressed && !rightWasPressed || Keyboard.current.sKey.wasPressedThisFrame)
            {
                isRunning = !isRunning;
            }

            if (leftPressed && !leftWasPressed || Keyboard.current.aKey.wasPressedThisFrame)
            {
                elapsedTime = 0f;
                isRunning = false;
            }

            if (isRunning)
            {
                elapsedTime += Time.deltaTime;
            }
            
            
            TimeSpan time = TimeSpan.FromSeconds(elapsedTime);
            string text = $"StopWatch:\n{time:mm\\:ss\\:ff}";
            
            
            leftWasPressed = ControllerInputPoller.instance.leftControllerPrimaryButton;
            rightWasPressed = ControllerInputPoller.instance.rightControllerPrimaryButton;
            
            return text;
        }
    }
}