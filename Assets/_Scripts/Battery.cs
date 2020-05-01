using System.Collections;
using System.Collections.Generic;
using CodeVenture;
using UnityEngine;

namespace CodeVenture
{
    public class Battery : MonoBehaviour, IProgrammable
    {
        [SerializeField] private string[] savedMethodNames;
        [SerializeField] private string[] correctCode;
        [SerializeField] private string infoText;
        [SerializeField] private string hintText;
        private bool completed = false;


        public string GetName(string test)
        {
            return "Batterij";
        }

        public string[] GetMethods()
        {
            return new[] { "EnergieInput"};
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

        private void EnergieInput(string energy)
        {
            if (energy == "100")
            {
                Tutorial.Instance.CollectedBattery++;
                Tutorial.Instance.SetQuestProgress();
                GameManager.Instance.score += 100;
                completed = true;
                UIHandler.Instance.CloseEditor();
                Destroy(this.gameObject);
            }
            else
            {
                completed = false;
            }
        }

        public void DoMethod(string name, string inputText)
        {
            EnergieInput(inputText);
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