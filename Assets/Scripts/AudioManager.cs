using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource musicSource;

    public AudioSource soundSource;

    public List<string> songNames;

    public List<string> soundNames;

    public List<AudioClip> songs;

    public List<AudioClip> sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMusic(string name) {
        musicSource.Stop();
        musicSource.clip = getMusicClip(name);
        if(musicSource.clip != null) {
            musicSource.Play();
        }
    }

    private AudioClip getMusicClip(string name) {
        int index = songNames.FindIndex(x => x.Equals(name));
        if(index == -1) {
            Debug.LogError("Song " + name + " not found!");
            return null;
        }
        return songs[index];
    }
}
