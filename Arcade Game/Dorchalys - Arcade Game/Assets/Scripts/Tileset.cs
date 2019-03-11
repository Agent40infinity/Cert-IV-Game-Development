﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tileset
{
    [AddComponentMenu("Tileset Generation")]
    public class Tileset : MonoBehaviour
    {
        public GameObject tile_32;
        public int tileWidth = 20; //Sets the max value for tile Width;
        public int tileHeight = 15; //Sets the max value for tile Height;
        public float[,] tileset_Layer1 =  //Top tileset layer for world initialization.
            {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
        public int[,] tileset_Layer2 = //Middle tileset layer for world initialization.
            {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
        public int[,] tileset_Layer3 = //Back tileset layer for world initialization.
            {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
        void Start()
        {
            //Declarations:
            Generation(); 
        }
        public void Generation() //Generates the array upon scene switch.
        {
            
            for (int y = 0; y < tileHeight; y++) //Checks the  Y position and value within the array to set it's content.
            {
                for (int x = 0; x < tileWidth; x++) //Checks the  X position and value within the array to set it's content.
                {
                    //Ignore Me ------->       print("tileWidth = " +tileWidth+ " Position("+x+ "," + y +") = " + tileset_Layer1[y, x]);
                    if (tileset_Layer1[y,x] == 0)
                    {
                        Instantiate(tile_32, new Vector3(x, y, 0), transform.rotation);
                    } 
                    if (tileset_Layer1[y,x] == 1)
                    {
                        Instantiate(tile_32, new Vector3(x, y, 0), transform.rotation);
                    }
                    if (tileset_Layer1[y,x] == 2)
                    {
                       
                    }
                    if (tileset_Layer1[y,x] == 3)
                    {
                        
                    }
                    if (tileset_Layer1[y,y] == 4)
                    {
                        
                    }
                }
            }
            for (int y = 0; y < tileHeight; y++) //Checks the  Y position and value within the array to set it's content.
            {
                for (int x = 0; x < tileWidth; x++) //Checks the  X position and value within the array to set it's content.
                {
                    //Ignore Me ------->       print("tileWidth = " +tileWidth+ " Position("+x+ "," + y +") = " + tileset_Layer1[y, x]);
                    if (tileset_Layer2[y, x] == 0)
                    {
                        Instantiate(tile_32, new Vector3(x, y, -1), transform.rotation);
                    }
                    if (tileset_Layer2[y, x] == 1)
                    {
                        Instantiate(tile_32, new Vector3(x, y, -1), transform.rotation);
                    }
                    if (tileset_Layer2[y, x] == 2)
                    {

                    }
                    if (tileset_Layer2[y, x] == 3)
                    {

                    }
                    if (tileset_Layer2[y, y] == 4)
                    {

                    }
                }
            }
            for (int y = 0; y < tileHeight; y++) //Checks the  Y position and value within the array to set it's content.
            {
                for (int x = 0; x < tileWidth; x++) //Checks the  X position and value within the array to set it's content.
                {
                    //Ignore Me ------->       print("tileWidth = " +tileWidth+ " Position("+x+ "," + y +") = " + tileset_Layer1[y, x]);
                    if (tileset_Layer3[y, x] == 0)
                    {
                        Instantiate(tile_32, new Vector3(x, y, -2), transform.rotation);
                    }
                    if (tileset_Layer3[y, x] == 1)
                    {
                        Instantiate(tile_32, new Vector3(x, y, -2), transform.rotation);
                    }
                    if (tileset_Layer3[y, x] == 2)
                    {

                    }
                    if (tileset_Layer3[y, x] == 3)
                    {

                    }
                    if (tileset_Layer3[y, y] == 4)
                    {

                    }
                }
            }
        }
    }
}

