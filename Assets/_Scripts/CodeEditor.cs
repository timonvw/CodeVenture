using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using CodeVenture;
using UnityEngine.UI;

namespace CodeVenture
{
    public class CodeEditor : MonoBehaviour
    {
        #region Singleton
        private static CodeEditor _instance;
        public static CodeEditor Instance
        {
            get
            {
                if (_instance == null)
                {
                    //uit nog niet nodig
                    //GameObject go = new GameObject("CodeEditor");
                    //go.AddComponent<CodeEditor>();
                }

                return _instance;
            }
        }
        #endregion

        //delegate event callback
        public delegate void CompletedChange(Color color);
        public static event CompletedChange OnCompleted; //lataaah gebruiken

        public IProgrammable EditableObject;

        public GameObject ToolBoxItemsObject;
        public Transform ToolboxItems;
        public GameObject MethodBlock;
        public GameObject MethodInputBlock;
        public Text InfoText;
        public Text HintText;
        public GameObject hintBox;
        public Text hintButtonText;
        private bool hintBool = false;

        public List<GameObject> ListCodeObjects = new List<GameObject>();
        public List<GameObject> ListCodeObjectsTool = new List<GameObject>();

        // Use this for initialization
        private void Start ()
        {
            //start values
            _instance = this;
        }

        public void SetInfoText()
        {
            StartCoroutine(TypeInfoText(EditableObject.GetInfoText()));
        }

        public void SetHintText()
        {
            StartCoroutine(TypeHintText(EditableObject.GetHintText()));
        }

        public void SetMethods ()
        {
            float pos = 0.7f;

            if (EditableObject != null)
            {
                string[] methods = EditableObject.GetMethods();
                foreach (string method in methods)
                {
                    Debug.Log(method);
                    GameObject mb;

                    if (method.Contains("Input"))
                    {
                        mb = Instantiate(MethodInputBlock, ToolboxItems.transform);
                    }
                    else
                    {
                        mb = Instantiate(MethodBlock, ToolboxItems.transform);
                    }
                  
                    mb.GetComponent<RectTransform>().localPosition = new Vector3(0, pos, 0);
                    mb.GetComponent<CodeVenture.MethodBlock>().SetStartPos();

                    pos -= 0.8f;
                    mb.name = method;

                    ListCodeObjectsTool.Add(mb);
                }
            }

            // load list
            LoadData();
        }

        public void SetCompleted(bool b)
        {
            if (OnCompleted != null)
            {
                OnCompleted(b ? Color.green : Color.white);
            }
        }

        public void OrderScript()
        {
            float yPosCounter = 0;

            foreach (GameObject codeObject in ListCodeObjects)
            {
                codeObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(3.6f, (1.4f - yPosCounter), codeObject.GetComponent<RectTransform>().transform.localPosition.z);
                yPosCounter++;
            }
        }

        public void OpenHintMenu()
        {
            hintBool = !hintBool;

            if (hintBool)
            {
                hintBox.SetActive(true);
                hintButtonText.text = "Sluit";
                SetHintText();
            }
            else
            {
                hintBox.SetActive(false);
                hintButtonText.text = "Hint";
            }
        }

        public void ClearEditor()
        {
            // save list
            SaveData();

            foreach (Transform child in ToolboxItems)
            {
                Destroy(child.gameObject);
            }

            ListCodeObjects.Clear();
            ListCodeObjectsTool.Clear();

            hintBox.SetActive(false);
        }

        public void ExecuteScript()
        {
            if (ListCodeObjects.Count > 0)
            {
                foreach (GameObject codeObject in ListCodeObjects)
                {
                    if (codeObject.name.Contains("Input"))
                    {
                        EditableObject.DoMethod(codeObject.name, codeObject.GetComponentInChildren<InputField>().text);
                    }
                    else
                    {
                        EditableObject.DoMethod(codeObject.name, "");
                    }
                }

                SaveData();

                SetCompleted(EditableObject.CheckCorrectCode());
            }
            
        }

        private void SaveData()
        {
            string[] methods = new string[ListCodeObjects.Count];
            int counterMethod = 0;

            foreach (GameObject codeOject in ListCodeObjects)
            {
                methods[counterMethod] = codeOject.name;
                counterMethod++;
            }

            EditableObject.SaveData(methods);
        }

        private void LoadData()
        {
            string[] methods = EditableObject.LoadData();

            foreach (string methodName in methods)
            {
                foreach (CanvasRenderer obj in ToolBoxItemsObject.GetComponentsInChildren<CanvasRenderer>())
                {
                    if (obj.gameObject.name == methodName)
                    {
                        ListCodeObjects.Add(obj.gameObject);
                    }
                }
            }

            OrderScript();

            //SetCompleted(EditableObject.CheckCompleted());
        }

        private IEnumerator TypeInfoText(string text)
        {
            InfoText.text = "";

            foreach (char letter in text)
            {
                InfoText.text += letter;
                yield return new WaitForSeconds(0.06f);
            }
        }

        private IEnumerator TypeHintText(string text)
        {
            HintText.text = "";

            foreach (char letter in text)
            {
                HintText.text += letter;
                yield return new WaitForSeconds(0.06f);
            }
        }

    }
}
