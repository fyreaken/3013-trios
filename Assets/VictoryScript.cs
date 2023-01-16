using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScript : MonoBehaviour
{

    [SerializeField]
    private GameObject victoryPanel;
    private void OnTriggerEnter(Collider other)
    {
        victoryPanel.SetActive(true);
        AudioListener.pause = true;
    }
}
