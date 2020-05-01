using System.Collections;
using UnityEngine;
using CodeVenture;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeVenture
{
    public class UIHandler : MonoBehaviour
    {
        #region Singleton
        private static UIHandler _instance;
        public static UIHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    //uit nog niet nodig
                    //GameObject go = new GameObject("UIHandler");
                    //go.AddComponent<UIHandler>();
                }

                return _instance;
            }
        }
        #endregion

        public GameObject CodeEditorPanel;
        public GameObject EditableObject { get; set; }
        public GameObject PauseMenu;
        public GameObject CameraEditableObject;
        public Text questLog;
        public Text buddyTextCloud;
        public GameObject buddyCloud;
        public Text playerNameHud;
        public Text scoreHud;
        public Text buddyNameHud;

        private bool openPauseMenu = false;

        void Awake()
        {
            questLog.text = "";
            buddyTextCloud.text = "";

            _instance = this;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                openPauseMenu = !openPauseMenu;
                PauseMenu.SetActive(openPauseMenu);
            }

            scoreHud.text = "Score: " + GameManager.Instance.score.ToString();
        }

        void LateUpdate()
        {
            if (EditableObject != null)
            {
                CameraEditableObject.transform.position = new Vector3(EditableObject.transform.position.x, EditableObject.transform.position.y, CameraEditableObject.transform.position.z);
            }
        }

        public void OpenEditor(bool b)
        {
            GameManager.Instance.StopMovement = true;

            if (EditableObject != null)
            {
                CodeEditorPanel.SetActive(b);

                CodeEditor.Instance.EditableObject = EditableObject.GetComponent<IProgrammable>();
                CodeEditor.Instance.SetInfoText();
                CodeEditor.Instance.SetMethods();
                MusicManager.Instance.PlayEditorOpen();
            }        
        }

        public void CloseEditor()
        {
            CodeEditor.Instance.ClearEditor();
            CodeEditorPanel.SetActive(false);
            GameManager.Instance.StopMovement = false;
            MusicManager.Instance.PlayButtonClick();
        }

        public void RunScript()
        {
            CodeEditor.Instance.ExecuteScript();
            MusicManager.Instance.PlayButtonClick();
        }

        public void OpenHintBox()
        {
            CodeEditor.Instance.OpenHintMenu();
            MusicManager.Instance.PlayButtonClick();
        }

        public void ToMenu()
        {
            MusicManager.Instance.PlayButtonClick();
            SceneManager.LoadSceneAsync(1);
        }

        public void SetQuestLog(string text)
        {
            questLog.text = text;
        }

        public void OpenBuddyCloud(bool b)
        {
            buddyCloud.SetActive(b);
        }

        public void SetCloudText(string text)
        {
            StartCoroutine(TextTyper(text));
        }

        private IEnumerator TextTyper(string text)
        {
            buddyTextCloud.text = "";

            foreach (char letter in text)
            {
                buddyTextCloud.text += letter;
                yield return new WaitForSeconds(0.06f);
            }
        }

        public void SetPlayerName(string name)
        {
            GameManager.Instance.PlayerName = name;
            playerNameHud.text = name;
        }

        public void SetBuddyName(string name)
        {
            GameManager.Instance.BuddyName = name;
            buddyNameHud.text = name;
        }
    }
}
