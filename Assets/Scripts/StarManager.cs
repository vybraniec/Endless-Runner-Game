using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    float lastStarTime = 0f;
    float timeDiff = 0.5f;
    public void StarSound(float currentStarTime){
        if(currentStarTime - lastStarTime < timeDiff){
                FindObjectOfType<AudioManager>().RaisePitch("chime-sound", 0.1f);
            }
            else{
                FindObjectOfType<AudioManager>().ResetPitch("chime-sound");
            }
            lastStarTime = currentStarTime;
    }
}
