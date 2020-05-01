using System.Collections.Generic;
using UnityEngine;
using CodeVenture;

namespace CodeVenture
{
    public class Car : MonoBehaviour, IProgrammable
    {
        [SerializeField]private string[] savedMethodNames;
        [SerializeField]private string[] correctCode;
        [SerializeField]private string infoText;
        [SerializeField]private string hintText;
        private bool completed = false;
        private bool driveForward = false;
        private bool driveBackward = false;
        private bool scoreOnce = false;

        public string GetName(string test)
        {
            return "Auto";
        }

        public string[] GetMethods()
        {
            return new[] {"RijVooruit", "RijAchteruit"};
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
                if (scoreOnce == false)
                {
                    GameManager.Instance.score += 100;
                    scoreOnce = true;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RijVooruit()
        {
            driveForward = true;
        }

        private void RijAchteruit()
        {
            driveBackward = true;
        }

        private void Update()
        {
            if (driveForward && this.transform.position.x >= 4.5f)
            {
                this.transform.Translate(transform.right * -2f * Time.deltaTime);
            }
            else
            {
                driveForward = false;
            }

            if (driveBackward && this.transform.position.x <= 6.3f)
            {
                this.transform.Translate(transform.right * 0.4f * Time.deltaTime);
            }
            else
            {
                driveBackward = false;
            }
        }

        public void DoMethod(string name, string inputText)
        {
            driveForward = false;
            driveBackward = false;

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
