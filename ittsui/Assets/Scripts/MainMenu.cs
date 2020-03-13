using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject PlayGame;
    public GameObject Chart;
    public GameObject Hira;
    public GameObject kata;
    public GameObject SelectMenu;
    public GameObject LoadScreen;

    public void Start()
    {
        PlayGame.SetActive(true);
        Chart.SetActive(false);
        Hira.SetActive(false);
        kata.SetActive(false);
        SelectMenu.SetActive(false);
        LoadScreen.SetActive(false);

    }
}
