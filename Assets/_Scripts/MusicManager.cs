using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CodeVenture
{
    public class MusicManager : MonoBehaviour
    {
        #region Singleton
        private static MusicManager _instance;
        public static MusicManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    //GameObject go = new GameObject(MusicManager");
                    //go.AddComponent<MusicManager>();
                }

                return _instance;
            }
        }
        #endregion

        [Header("Mixers")]
        public AudioMixer masterMixer;

        [Header("Audio sources")]
        public AudioSource Muziek;
        public AudioSource Effecten;
        public AudioSource EffectenLoop;

        [Header("Audio clips")]
        public AudioClip MenuMusic;
        public AudioClip mainMuziek;

        //effects
        public AudioClip editorOpen;
        public AudioClip buttonPress;
        public AudioClip walk;
        public AudioClip highFive;


        public float muziekVolume { get; set; }
        public float effectVolume { get; set; }
        private bool playOnce = false;

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            //start values
            _instance = this;
            muziekVolume = 1;
            effectVolume = 1;
        }

        public void stopAll()
        {
            Muziek.Stop();
            Effecten.Stop();
            EffectenLoop.Stop();
        }

        public void PauzeMusic()
        {
            Muziek.Pause();
            Effecten.Pause();
            EffectenLoop.Pause();
        }

        public void UnPauzeMusic()
        {
            Muziek.UnPause();
            Effecten.UnPause();
            EffectenLoop.UnPause();
        }

        #region One shots (effects) functions
        //Play one shots (effects)
        public void PlayButtonClick()
        {
            Effecten.PlayOneShot(buttonPress, 1f);
        }

        public void PlayHighFive()
        {
            Effecten.PlayOneShot(highFive, 1f);
        }
        public void PlayEditorOpen()
        {
            Effecten.PlayOneShot(editorOpen, 1f);
        }

        #endregion

        #region Normal sounds functions
        public void PlayWalkSound()
        {
            if (playOnce == false)
            {
                EffectenLoop.clip = walk;
                EffectenLoop.Play();
                playOnce = true;
            }
        }

        public void StopWalkSound()
        {
            EffectenLoop.Stop();
            playOnce = false;
        }

        #endregion

        #region Stop sounds
        //stop sounds
        #endregion

        #region set functions
        //set functions
        public void SetMasterLevelLVl(float masterLvl)
        {
            masterMixer.SetFloat("masterVolume", masterLvl);
            masterMixer.SetFloat("sfxVolume", masterLvl);
            masterMixer.SetFloat("musicVolume", masterLvl);
        }

        public void SetSfxLVl(float sfxLvl)
        {
            masterMixer.SetFloat("sfxVolume", sfxLvl);
        }

        public void SetMusicLVl(float musicLvl)
        {
            masterMixer.SetFloat("musicVolume", musicLvl);
        }

        public void SetMenuMusic()
        {
            Muziek.clip = MenuMusic;
            Muziek.Play();
        }

        public void SetMainMusic()
        {
            Muziek.clip = mainMuziek;
            Muziek.Play();
        }

        #endregion
    }
}