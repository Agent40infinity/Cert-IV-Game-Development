using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [Header("Personal")]
        public int x, y;
        public bool isMine = false;
        public bool isRevealed = false;

        [Header("References")]
        public Sprite[] emptySprites;
        public Sprite[] mineSprites;
        private SpriteRenderer rend;

        void Awake() //Used to get the components required.
        {
            rend = GetComponent < SpriteRenderer>();
        }

        void Start() //Determines the chance of whether or not a tile spawns as a mine.
        {
            isMine = Random.value < .15f;
        }

        public void Reveal(int adjacentMines, int mineState = 0) //Allows a tile to be revealed and changes the sprite in accordance
        {
            isRevealed = true;
            if (isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}
