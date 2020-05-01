using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeVenture
{
    public class Portal : MonoBehaviour, IProgrammable
    {
        [SerializeField] private string[] savedMethodNames;
        [SerializeField] private string[] correctCode;
        [SerializeField] private string infoText;
        [SerializeField] private string hintText;
        private bool completed = false;
        

        public string GetName(string test)
        {
            return "Portaal";
        }

        public string[] GetMethods()
        {
            return new[] { "ZetBatterij1", "ZetBatterij2", "ZetKabel"};
        }

        public string GetInfoText()
        {
            return infoText;
        }

        public string GetHintText()
        {
            return hintText;
        }

        public bool CheckCompleted()
        {
            if (completed)
            {
                return completed;
            }
            else
            {
                return completed;
            }
        }

        public bool CheckCorrectCode()
        {
            if (correctCode[0] == savedMethodNames[0] && savedMethodNames.Length == correctCode.Length)
            {
                completed = true;
                GameManager.Instance.score++;
                UIHandler.Instance.CloseEditor();
                Tutorial.Instance.StartPart(5);
                this.gameObject.tag = "Untagged";
                Destroy(this.gameObject.GetComponent<BoxCollider2D>());
                Destroy(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ZetBatterij1()
        {
           
        }

        private void ZetBatterij2()
        {
           
        }

        private void ZetKabel()
        {

        }

        public void DoMethod(string name, string inputText)
        {
            Invoke(name, 0);
        }

        // save and load
        public void SaveData(string[] methodNames)
        {
            savedMethodNames = methodNames;
        }

        public string[] LoadData()
        {
            return savedMethodNames;
        }
    }
}

