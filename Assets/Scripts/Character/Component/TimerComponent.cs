using System;
using UnityEngine;

namespace Character.Component
{
    public class TimerComponent : MonoBehaviour
    {
        private float waitingTime;
        private float countdown;

        private bool timeRunning;
        public void Pause() => timeRunning = false;
        public void Run() => timeRunning = true;

        public Action OnCountdownCompleted;

        private void Start() => countdown = waitingTime;

        public void Configuration(Characteristics characteristics)
        {
            waitingTime = characteristics.WaitingTime;
        }

        private void Update()
        {
            if (timeRunning == false) return;
            
            countdown -= Time.deltaTime;
            if (countdown > 0) return;

            countdown = waitingTime;
            OnCountdownCompleted?.Invoke();
        }
    }
}