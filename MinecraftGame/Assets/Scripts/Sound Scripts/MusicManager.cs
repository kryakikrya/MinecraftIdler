using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<AudioClip> _songs;
    private int _songId = 0;
    public void ChangeAudioClip(AudioClip _newClip)
    {
        _audioSource.clip = _newClip;
    }
    public void PlayAudio()
    {
        _audioSource.PlayDelayed(1);
    }

    private void Update()
    {
        if (_audioSource.isPlaying == false)
        {
            print("Change song");
            ChangeAudioClip(_songs[_songId]);
            PlayAudio();
            if (_songId < _songs.Count - 1)
            {
                _songId++;
            }
            else
            {
                _songId = 0;
            }
        }
    }
}
