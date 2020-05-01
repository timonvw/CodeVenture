using System.Collections;
using System.Collections.Generic;
using CodeVenture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    #region Singleton
    private static Tutorial _instance;
    public static Tutorial Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("Tutorial");
                //go.AddComponent<Tutorial>();
            }

            return _instance;
        }
    }
    #endregion

    public int CollectedBattery{ get; set; }
    public int CollectedCable { get; set; }

    public GameObject playerNameObject;
    public GameObject buddyNameObject;
    public GameObject Portal;
    public GameObject portalMiddle;
    public GameObject endScreen;

    // Use this for initialization
    void Start ()
    {
        _instance = this;

        CollectedBattery = 0;
        CollectedCable = 0;

        StartCoroutine(introTutorial());
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Buddy crashed in de tuin, speler komt er in gerent
        //buddy vertelt alles
        //speler vult buddy's naam in in CodeEditor
        //speler vult eigen naam in in CodeEditor
        //buddy zet een portal neer
        //speler moet alle 2 de batterijen zoeken
        //speler moet de kabel zoeken

        if (CollectedBattery == 2 && CollectedCable == 1)
        {
            StartPart(4);
            CollectedBattery++;
        }
    }

    public void StartPart(int part)
    {
        switch (part)
        {
            case 2:
                StartCoroutine(TutorialPart2());
                break;
            case 3:
                StartCoroutine(TutorialPart3());
                break;
            case 4:
                StartCoroutine(TutorialPart4());
                break;
            case 5:
                StartCoroutine(TutorialPart5());
                break;
        }
    }

    public void SetQuestProgress()
    {
        UIHandler.Instance.SetQuestLog("Aantal batterijen gevonden " + CollectedBattery + "/2\n\nKabel gevonden " + CollectedCable + "/1");
    }

    private IEnumerator introTutorial()
    {
        GameManager.Instance.StopMovement = true;
        UIHandler.Instance.SetCloudText("Help me, alsjeblieft. Mijn planeet is verwoest.");
        yield return new WaitForSeconds(8f);
        UIHandler.Instance.SetCloudText("Het is verwoest door aliens genaamd Epsies. En ze gaan nu jouw planeet vernietigen !");
        yield return new WaitForSeconds(10f);
        UIHandler.Instance.SetCloudText("Om jou planeet te redden ga ik jou leren programmeren. Hiermee kan je de Epsies verslaan en de wereld bewerken !");
        yield return new WaitForSeconds(15f);
        UIHandler.Instance.SetCloudText("Hoe heet je eigenlijk?");
        yield return new WaitForSeconds(2f);
        UIHandler.Instance.EditableObject = playerNameObject;
        UIHandler.Instance.OpenEditor(true);
    }

    private IEnumerator TutorialPart2()
    {
        UIHandler.Instance.SetCloudText("Coole naam " + GameManager.Instance.PlayerName + " Waar ik vandaan kom hebben we geen naam.");
        yield return new WaitForSeconds(8f);
        UIHandler.Instance.SetCloudText("Maar je mag wel een naam voor mij verzinnen: ");
        yield return new WaitForSeconds(4f);
        UIHandler.Instance.EditableObject = buddyNameObject;
        UIHandler.Instance.OpenEditor(true);
    }

    private IEnumerator TutorialPart3()
    {
        UIHandler.Instance.SetCloudText("Ik heet nu voortaan: " + GameManager.Instance.BuddyName + ", leuke naam !");
        yield return new WaitForSeconds(5f);
        UIHandler.Instance.SetCloudText("Om de wereld te redden moeten we teleporteren naar de andere kant van de wereld !");
        yield return new WaitForSeconds(10f);
        UIHandler.Instance.SetCloudText("Hiervoor heb ik een teleporteer machine, alleen mis ik een paar onderdelen.");
        Portal.SetActive(true);
        yield return new WaitForSeconds(10f);
        UIHandler.Instance.SetCloudText("Wat ik nodig heb zijn 2 batterijen en 1 kabel, ze liggen hier ergens in de tuin.");
        yield return new WaitForSeconds(10f);
        UIHandler.Instance.SetCloudText("Rechts boven staat een 'Te Doen' lijst waar je kan zien hoe ver je bent en wat je moet doen.");
        UIHandler.Instance.SetQuestLog("Aantal batterijen gevonden 0/2\n\nKabel gevonden 0/1");
        yield return new WaitForSeconds(10f);
        UIHandler.Instance.SetCloudText("De 2 batterijen liggen op de grond en de kabel ligt onder een auto, Succes !");
        GameManager.Instance.StopMovement = false;
    }

    private IEnumerator TutorialPart4()
    {
        UIHandler.Instance.SetCloudText("Woohoo het is je gelukt, je hebt alle voorwerpen verzameld !");
        yield return new WaitForSeconds(10f);
        UIHandler.Instance.SetCloudText("Ga snel naar het teleporteer machine toe en voeg alles samen");
        Portal.gameObject.tag = "Editable";
        UIHandler.Instance.SetQuestLog("Voeg alle voorwerpen toe aan het teleporteer machine");
    }

    private IEnumerator TutorialPart5()
    {
        portalMiddle.SetActive(true);
        UIHandler.Instance.SetCloudText("Goed gedaan, het portaal is nu klaar voor gebruikt, laten we gaan en de wereld redden!");
        UIHandler.Instance.SetQuestLog("");
        yield return new WaitForSeconds(10f);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadSceneAsync(1);
    }
}
