using System;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MiniZadanie3
{
    public partial class MainPage : ContentPage
    {
        private bool isFirstButtonClick = true;

        string song1 = "Ghost.mp3";
        string song2 = "No Guts No Glory.mp3";
        string song3 = "Zero to Hero.mp3";

        public MainPage()
        {
            InitializeComponent();
            MediaPlayer.Source = MediaSource.FromResource(song1);
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
                ChangeLabel($"Now playing {MediaPlayer.Source}", Color.FromRgb(118, 165, 175));
                MediaPlayer.Play();
                PlayButton.IsVisible = false;
                PauseButton.IsVisible = true;
            }
        }

        private void NextPrevButton_Clicked(object sender, EventArgs e)
        {
            if (sender == PrevButton)
            {
                if (MediaPlayer.Source?.ToString().Contains(song2, StringComparison.OrdinalIgnoreCase) == true)
                {
                    MediaPlayer.Source = MediaSource.FromResource(song1);
                    ChangeLabel($"Now playing {MediaPlayer.Source}", Color.FromRgb(118, 165, 175));
                    MediaPlayer.Play();
                    PrevButton.IsEnabled = false;
                }
                else if (MediaPlayer.Source?.ToString().Contains(song3, StringComparison.OrdinalIgnoreCase) == true)
                {
                    MediaPlayer.Source = MediaSource.FromResource(song2);
                    ChangeLabel($"Now playing {MediaPlayer.Source}", Color.FromRgb(118, 165, 175));
                    MediaPlayer.Play();
                    NextButton.IsEnabled = true;
                }
            }
            else if (sender == NextButton)
            {
                if (MediaPlayer.Source?.ToString().Contains(song1, StringComparison.OrdinalIgnoreCase) == true)
                {
                    MediaPlayer.Source = MediaSource.FromResource(song2);
                    ChangeLabel($"Now playing {MediaPlayer.Source}", Color.FromRgb(118, 165, 175));
                    MediaPlayer.Play();
                    PrevButton.IsEnabled = true;
                }
                else if (MediaPlayer.Source?.ToString().Contains(song2, StringComparison.OrdinalIgnoreCase) == true)
                {
                    MediaPlayer.Source = MediaSource.FromResource(song3);
                    ChangeLabel($"Now playing {MediaPlayer.Source}", Color.FromRgb(118, 165, 175));
                    MediaPlayer.Play();
                    NextButton.IsEnabled = false;
                }
            }
        }

        private void ChangeLabel(string text, Color textColor)
        {
            LableText.Text = text;
            LableText.TextColor = textColor;
        }
    }
}
