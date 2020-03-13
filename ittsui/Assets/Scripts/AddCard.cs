using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour {

    [SerializeField]
    private Transform board;

    [SerializeField]
    private GameObject btn;

    void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(board, false);
        }
    }
}
