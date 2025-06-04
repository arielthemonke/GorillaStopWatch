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
        private bool primaryWasPressed;
        private bool secondaryWasPressed;
        
        public string PageName => "Gorilla StopWatch";
        
        public string GetPageText()
        {
            bool primaryPressed = ControllerInputPoller.instance.rightControllerPrimaryButton;
            bool secondaryPressed = ControllerInputPoller.instance.rightControllerSecondaryButton;
            
            if (primaryPressed && !primaryWasPressed || Keyboard.current.sKey.wasPressedThisFrame)
            {
                isRunning = !isRunning;
            }

            if (secondaryPressed && !secondaryWasPressed || Keyboard.current.aKey.wasPressedThisFrame)
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
            
            
            primaryWasPressed = ControllerInputPoller.instance.rightControllerPrimaryButton;
            secondaryWasPressed = ControllerInputPoller.instance.rightControllerSecondaryButton;
            
            return text;
        }
    }
}