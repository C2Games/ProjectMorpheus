﻿using SFML.Audio;

namespace ProjectMorpheus
{
    internal static class SoundManager
    {
        private static Music song;
        private static int musicVolume;
                
        private const int maxSounds = 255; 
        private static Sound[] sounds;
        private static int soundsIndex;
        private static int soundVolume;

        public static void Load() {
            musicVolume = 100;
            soundVolume = 100;
            sounds = new Sound[maxSounds];
        }

        public static void PlayMusic(string filename, bool looping = true) {
            if (song != null) {
                song.Stop();
            }
            song = new Music(filename);
            song.Loop = true;
            song.Volume = musicVolume;
            song.Play();
        }

        public static void ResumeMusic() {
            if (song.Status != SoundStatus.Playing) {
                song.Play();
            }
        }

        public static void PauseMusic() {
            song.Pause();
        }

        public static void StopMusic() {
            song.Stop();
        }

        public static void SetMusicVolume(int volume) {
            if (volume < 0) volume = 0;
            if (volume > 100) volume = 100;
            musicVolume = volume;
        }

        public static void PlaySound(string soundname) {
            Sound s = new Sound(ContentManager.GetSound(soundname));
            s.Volume = soundVolume;
            s.Play();

            if (sounds[soundsIndex] != null) {
                sounds[soundsIndex].Stop();
            }
            sounds[soundsIndex] = s;
            soundsIndex = (soundsIndex + 1) % maxSounds;
        }

        public static void SetSoundVolume(int volume) {
            if (volume < 0) volume = 0;
            if (volume > 100) volume = 100;
            soundVolume = volume;
        }
    }
}
