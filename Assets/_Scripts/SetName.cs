using System.Collections;
using System.Collections.Generic;
using CodeVenture;
using UnityEngine;

namespace CodeVenture
{
    public class SetName : MonoBehaviour, IProgrammable
    {
        [SerializeField] private string[] savedMethodNames;
        [SerializeField] private string[] correctCode;
        [SerializeField] private string infoText;
        [SerializeField] private string hintText;
        private bool completed = false;


        public string GetName(string test)
        {
            return "jewNaam";
        }

        public string[] GetMethods()
        {
            return new[] { "jeNaamInput" };
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
            return completed;
        }

        private void ChangeName(string name)
        {
            if (name != "")
            {
                UIHandler.Instance.SetPlayerName(name);
                completed = true;
                UIHandler.Instance.CloseEditor();
                Tutorial.Instance.StartPart(2);
                GameManager.Instance.StopMovement = true;
                GameManager.Instance.score += 100;
                Destroy(this.gameObject);
            }
            else
            {
                completed = false;
            }
        }

        public void DoMethod(string name, string inputText)
        {
            ChangeName(inputText);
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
