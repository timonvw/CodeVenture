using UnityEngine;
using CodeVenture;

namespace CodeVenture
{
    public class GameManager : MonoBehaviour
    {

        #region Singleton
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    //uit nog niet nodig
                    //GameObject go = new GameObject("GameManager");
                    //go.AddComponent<GameManager>();
                }

                return _instance;
            }
        }
        #endregion

        public bool StopMovement = false;
        public string PlayerName { get; set; }
        public string BuddyName { get; set; }
        public int score { get; set; }

        void Awake()
        {
            MusicManager.Instance.SetMainMusic();    
        }

        // Use this for initialization
        void Start()
        {
            //start values
            _instance = this;

            score = 0;
        }

    }
}
