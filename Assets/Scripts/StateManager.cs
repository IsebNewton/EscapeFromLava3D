using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public sealed class StateManager
    {
        private static readonly StateManager instance = new StateManager();

        static StateManager()
        {
        }

        public static StateManager Instance
        {
            get
            {
                return instance;
            }
        }

        public enum State
        {
            MainMenuState,
            StoryState,
            PlayState,
            PausedState
        }

        private State currentState;

        public static State GetCurrentState()
        {
            return Instance.currentState;
        }

        public static void SetCurrentState(State state)
        {
            Instance.currentState = state;
        }

        public static bool IsMainMenuState()
        {
            return Instance.currentState == State.MainMenuState;
        }

        public static bool IsPlayState()
        {
            return Instance.currentState == State.PlayState;
        }

        public static bool IsPausedState()
        {
            return Instance.currentState == State.PausedState;
        }
    }
}
