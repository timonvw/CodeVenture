using System.Collections;
using System.Collections.Generic;
using CodeVenture;
using UnityEngine;

public class SetNameBuddy : MonoBehaviour, IProgrammable
{
    [SerializeField] private string[] savedMethodNames;
    [SerializeField] private string[] correctCode;
    [SerializeField] private string infoText;
    [SerializeField] private string hintText;
    private bool completed = false;


    public string GetName(string test)
    {
        return "zijnNaam";
    }

    public string[] GetMethods()
    {
        return new[] { "zijnNaamInput" };
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
            UIHandler.Instance.SetBuddyName(name);
            completed = true;
            UIHandler.Instance.CloseEditor();
            Tutorial.Instance.StartPart(3);
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
