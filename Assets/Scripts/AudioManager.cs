using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Start()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.Loop;
            s.source.volume = s.volume;
        }
    }

    public void PlaySound(string name){
        foreach(Sound s in sounds){
            if (s.name == name){
                s.source.Play();
            }
        }
    }

    public void StopSound(string name){
        foreach(Sound s in sounds){
            if (s.name == name){
                s.source.Stop();
            }
        }
    }

    public void RaisePitch(string name, float value){
        foreach(Sound s in sounds){
            if (s.name == name){
                s.source.pitch += 0.2f;
            }
        }
    }

    public void ResetPitch(string name){
        foreach(Sound s in sounds){
            if (s.name == name){
                s.source.pitch = 1;
            }
        }
    }
}
