﻿// Copyright (C) 2022 Geronimo Games - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.

using System;
using UnityEngine;

namespace GeronimoGames.Firefly.Game
{
    public class TimerGame : MonoBehaviour
    {
        private float elapsedTime;
        private float startTime;
        private bool start;

        public event Action<string> OnTimer;

        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        private void Update()
        {
            if (!start)
            {
                return;
            }

            elapsedTime = Time.time - startTime;

            Minutes = (int) elapsedTime / 60;
            Seconds = (int) elapsedTime % 60;
            OnTimer?.Invoke($"{Minutes:00}:{Seconds:00}");
        }

        public void Run()
        {
            startTime = Time.time;
            start = true;
        }

        public void Stop()
        {
            start = false;
        }
    }
}