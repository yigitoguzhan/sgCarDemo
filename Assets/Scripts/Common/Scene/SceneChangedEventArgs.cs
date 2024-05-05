using System;

namespace SuperGearsGames.Demo.Common
{
    public class SceneChangedEventArgs : EventArgs
    {
        public string PreviousSceneName { get; set; }
        public string CurrentSceneName { get; set; }
    }
}