using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerAnimal : MonoBehaviour {

    [SerializeField]
    private Sprite bgImage;

    public Sprite[] cards;

    public List<Sprite> gameCards = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    public GameObject GameOver;

    public GameObject TheBoard;

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuessese;

    private int firstGuessIndex, secoudGuessIndex;
    private string firstGuessPuzzle, secoudGuessPuzzle;

    void Awake()
    {

        cards = Resources.LoadAll<Sprite>("Animal");

    }

    void Start()
    {
        GetButtons();
        AddListener();
        AddGamePair();
        Shuffle(gameCards);
        gameGuessese = gameCards.Count / 2;

    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Card");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePair()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)

            {
                index = 0;
            }

            gameCards.Add(cards[index]);

            index++;
        }
    }

    void AddListener()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickACard());
        }
    }

    void PickACard()
    {
        if (!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gameCards[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;

            secoudGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secoudGuessPuzzle = gameCards[secoudGuessIndex].name;

            btns[secoudGuessIndex].image.sprite = gameCards[secoudGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfTheCardMatched());

        }

    }
    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuessese)
        {
            TheBoard.SetActive(false);

            GameOver.SetActive(true);

            Debug.Log("Game Finished");
            Debug.Log("It took you" + countGuesses + " time to guesses to finish the game");
        }
    }

    IEnumerator CheckIfTheCardMatched()
    {
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secoudGuessPuzzle)
        {
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secoudGuessIndex].interactable = false;

            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secoudGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(0.5f);

        firstGuess = secondGuess = false;
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
