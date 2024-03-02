using System;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Collections.Generic;

namespace MiniZadanie3
{
    public partial class MainPage : ContentPage
    {
        private bool isFirstButtonClick = true;
        private List<string> playlist = new List<string>
        {
            "Ghost.mp3",
            "No Guts No Glory.mp3",
            "Zero to Hero.mp3"
        };
        private int currentSongIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            MediaPlayer.Source = MediaSource.FromResource(playlist[currentSongIndex]);
        }

        private void PlayPauseButton_Clicked(object sender, EventArgs e)
        {
            if (isFirstButtonClick)
            {
                NextButton.IsEnabled = true;
                isFirstButtonClick = false;
            }

            if (MediaPlayer.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
            {
                ChangeLabel("Paused...", Color.FromRgb(250, 201, 0));
                MediaPlayer.Pause();
                PlayButton.IsVisible = true;
                PauseButton.IsVisible = false;
            }
            else
            {
                ChangeLabel($"Now playing {playlist[currentSongIndex]}", Color.FromRgb(118, 165, 175));
                MediaPlayer.Play();
                PlayButton.IsVisible = false;
                PauseButton.IsVisible = true;
            }
        }

        private void NextPrevButton_Clicked(object sender, EventArgs e)
        {
            if (sender == PrevButton)
            {
                currentSongIndex = (currentSongIndex - 1 + playlist.Count) % playlist.Count;
            }
            else if (sender == NextButton)
            {
                currentSongIndex = (currentSongIndex + 1) % playlist.Count;
            }

            MediaPlayer.Source = MediaSource.FromResource(playlist[currentSongIndex]);
            ChangeLabel($"Now playing {playlist[currentSongIndex]}", Color.FromRgb(118, 165, 175));

            PrevButton.IsEnabled = currentSongIndex != 0;
            NextButton.IsEnabled = currentSongIndex != playlist.Count - 1;

            if (MediaPlayer.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
            {
                MediaPlayer.Play();
            }
        }

        private void ChangeLabel(string text, Color textColor)
        {
            LableText.Text = text;
            LableText.TextColor = textColor;
        }
    }
}
