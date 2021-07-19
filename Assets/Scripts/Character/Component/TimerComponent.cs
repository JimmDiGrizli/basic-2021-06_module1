using System;
using UnityEngine;

namespace Character.Component
{
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField] private float waitingTime;
        public float WaitingTime => waitingTime;
        
        private float countdown;

        private bool timeRunning = false;
        public void Pause() => timeRunning = false;
        public void Run() => timeRunning = true;

        public Action OnCountdownCompleted;

        private void Start() => countdown = waitingTime;

        void Update()
        {
            if (timeRunning == false) return;
            
            countdown -= Time.deltaTime;
            if (countdown > 0) return;

            countdown = waitingTime;
            OnCountdownCompleted?.Invoke();
        }
    }
}