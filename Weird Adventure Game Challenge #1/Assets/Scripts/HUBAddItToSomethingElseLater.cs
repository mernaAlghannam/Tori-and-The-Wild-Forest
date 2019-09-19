using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUBAddItToSomethingElseLater : MonoBehaviour
{
    public Sprite[] CarrotsSprites;

    public Image CarrotsUI;

    private PlayerTwoMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerTwoMovement>().GetComponent<PlayerTwoMovement>();

    }

    void Update()
    {
        CarrotsUI.sprite = CarrotsSprites[player.currentHealth];
    }
}
