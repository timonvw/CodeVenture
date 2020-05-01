using System.Collections;
using System.Collections.Generic;
using CodeVenture;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Tutorial.Instance.CollectedCable++;
            Tutorial.Instance.SetQuestProgress();
            GameManager.Instance.score += 100;
            Destroy(this.gameObject);
        }
    }
}
