﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;                         //Array (list) of all backgrounds and fregrounds to be parallaxed
    float[] parallaxScales;                                 //Proportion of the cameras movement to move the background by
    float smoothing = 1f;                                   //How smooth the parallax is going to be. Make sure to set this above zero

    Transform cam;                                          // reference to the main cameras transform
    Vector3 previousCamPos;                                 //Stores the position of the camera of the previous frame

    //Called before Start(). Great for references
    void Awake()
    {
        //set up the camera reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //previous frame had the current frame's camera position
        previousCamPos = cam.position;

        //assigning coresponding parallax scales
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //the parallax is the opposite of the camera movement, beouse the previous frame is multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set a target x position which is the current position + the parallax
            float backgrounTargetPosX = backgrounds[i].position.x + parallax;
        }
    }
}
