using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
        [Header("---------------- Audio Sources ----------------")]
        [SerializeField] AudioSource bgSource;
        [SerializeField] AudioSource sfxSource;

        [Header("---------------- Audio Clips ----------------")]
        public AudioClip bg;
        public AudioClip death;
        public AudioClip win;
        public AudioClip move;
        public AudioClip stopMove;
        
        
        public static AudioManager Instance;
        private void Awake()
        {
                if (Instance == null)
                {
                        Instance = this;
                        DontDestroyOnLoad(gameObject);
                }
                else
                {
                        Destroy(gameObject);
                }
        }

        private void Start()
        {
                bgSource.clip = bg;
                bgSource.Play();
        }

        private readonly Dictionary<AudioClip, Stopwatch> _cooldowns = new();
        private readonly TimeSpan _cooldownTime = TimeSpan.FromMilliseconds(250);
        public void PlaySfx(AudioClip audio)
        {
                if (_cooldowns.TryGetValue(audio, out var stopwatch))
                {
                        if (stopwatch.Elapsed < _cooldownTime)
                        {
                                // Demasiado pronto, ignoramos la llamada
                                return;
                        }
                        stopwatch.Restart(); // Reiniciamos para la próxima vez
                }
                else
                {
                        stopwatch = Stopwatch.StartNew();
                        _cooldowns[audio] = stopwatch;
                }
                sfxSource.PlayOneShot(audio);
        }
}