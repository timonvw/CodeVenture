using System.Collections.Generic;
using UnityEngine;

namespace CodeVenture
{
    public interface IProgrammable
    {
        string GetName(string test);
        string[] GetMethods();
        string[] LoadData();
        string GetInfoText();
        string GetHintText();
        bool CheckCorrectCode();
        bool CheckCompleted();

        void DoMethod(string name, string inputText);
        void SaveData(string[] methodNames);
    }
}