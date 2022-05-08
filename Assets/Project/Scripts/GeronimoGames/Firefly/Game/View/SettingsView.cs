﻿// Copyright (C) 2022 Geronimo Games - All Rights Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.

using System;
using UnityEngine;
using UnityEngine.UI;

namespace GeronimoGames.Firefly.Game
{
    public class SettingsView : View
    {
        [Header("BUTTONS")]
        [SerializeField]
        private Button closeButton;

        [Header("TOGGLES")]
        [SerializeField]
        private Toggle musicToggle;

        public event Action<bool> OnClose;

        private bool isMusic;
        private bool isParticles;

        private void OnEnable()
        {
            closeButton.onClick.AddListener(() => { OnClose?.Invoke(false); });

            musicToggle.onValueChanged.AddListener(value =>
            {
                AudioListener.pause = !value;
                isMusic = AudioListener.pause;

                Prefs.SetBool("game_music", isMusic);
            });
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveAllListeners();
            musicToggle.onValueChanged.RemoveAllListeners();
        }

        public void Initialize()
        {
            musicToggle.isOn = !Prefs.GetBool("game_music");
            AudioListener.pause = Prefs.GetBool("game_music");
        }
    }
}