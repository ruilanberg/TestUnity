using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector = null;

        [SerializeField] private UnityEvent _startGameEvent;
        [SerializeField] private UnityEvent _endGameEvent;


        private static GameManager _instance = null;
        public static GameManager Instance
        {
            get
            {
                if(_instance == null)
                    _instance = FindObjectOfType<GameManager>();

                return _instance;
            }
        }

        private void Start()
        {
            _playableDirector.stopped += _ => InitGame();
        }

        public void InitGame()
        {
            Debug.Log("Init Game");

            _startGameEvent.Invoke();
        }

        public void EndGame()
        {
            Debug.Log("End Game");

            _endGameEvent.Invoke();
        }

        public void AddEventInStartGame(Action gameEvent)
        {
            _startGameEvent.AddListener(() => gameEvent.Invoke());
        }
    }
}
