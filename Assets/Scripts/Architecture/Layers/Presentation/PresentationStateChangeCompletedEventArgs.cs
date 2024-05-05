using System;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class PresentationStateChangeCompletedEventArgs : EventArgs
    {
        public string CurrentSceneName { get; }
        public string PreviousSceneName { get; }

        public PresentationStateChangeCompletedEventArgs(string previousSceneName, string currentSceneName)
        {
            PreviousSceneName = previousSceneName;
            CurrentSceneName = currentSceneName;
        }
    }
}