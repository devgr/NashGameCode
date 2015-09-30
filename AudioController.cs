/*
Add to an empty game object to make a basic audio manager for your game.
Put references to the following components in the inspector
    AudioSource component on a 3D object, set to 3D spatial spread. (Connect to audSource3D)
    AudioSource component on a 3D object, set to 3D spatial spread. (Connect to audSource3D2)
    AudioSource component anywhere, set to 2D spatial spread. (Connect to audSource2D)
    AudioSource component anywhere, set to 2D spatial spread. (Connect to backgroundMusic)

Use this class's public methods to play audio clips or add them to a queue to play after other sounds.
*/

using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

    public AudioClip[] soundClips; // place all of your clips here via the inspector
    public AudioClip backgroundClip; // background music clip

    public AudioSource audSource3D; // continuous looping sound for a 3D object
    public AudioSource audSource3D2; // sound effects from a 3D object
    public AudioSource audSource2D; // sound effects like achievements, objectives, etc
    public AudioSource backgroundMusic; // looping background music

    protected Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    protected List<AudioClip> playQueue3D = new List<AudioClip>();
    protected List<AudioClip> playQueue2D = new List<AudioClip>();

    void Start()
    {
        for (int i = 0; i < soundClips.Length; i++)
            clips.Add(soundClips[i].name, soundClips[i]);

        backgroundMusic.clip = backgroundClip;
        backgroundMusic.loop = true;
        backgroundMusic.Play();

        // PlayOneThenLoop3D("EngineOn", "Whir" ); // start these clips when the game starts
    }

    void Update()
    {
        // 3D audio queue
        if (!audSource3D2.isPlaying && playQueue3D.Count > 0)
        {
            audSource3D2.clip = playQueue3D[0];
            audSource3D2.loop = false;

            audSource3D2.Play();
            playQueue3D.RemoveAt(0);
        }

        // 2D audio queue
        if (!audSource2D.isPlaying && playQueue2D.Count > 0)
        {
            audSource2D.clip = playQueue2D[0];
            audSource2D.loop = false;

            audSource2D.Play();
            playQueue2D.RemoveAt(0);
        }
    }
	
    public void PlayClip3D(string name){
        audSource3D2.clip = clips[name];
        audSource3D2.loop = false;
        audSource3D2.Play();
    }
    public void PlayLoop3D(string name)
    {
        audSource3D.clip = clips[name];
        audSource3D.loop = true;
        audSource3D.Play();
    }
    public void StopLoop3D()
    {
        audSource3D.Stop();
    }
    public void AddTo3DQueue(string name)
    {
        playQueue3D.Add(clips[name]);
    }

    public void PlayClip2D(string name)
    {
        audSource2D.clip = clips[name];
        audSource2D.loop = false;
        audSource2D.Play();
    }
    public void AddTo2DQueue(string name)
    {
        playQueue2D.Add(clips[name]);
    }

    public void PlayOneThenLoop3D(string first, string second)
    {
        audSource3D2.clip = clips[first];
        audSource3D2.Play();
        audSource3D.clip = clips[second];
        audSource3D.loop = true;
        audSource3D.PlayDelayed(clips[first].length);
    }
}
