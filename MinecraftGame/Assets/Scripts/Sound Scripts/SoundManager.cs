using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _subSource;
    [SerializeField] List<AudioClip> _sounds;
    public void ChangeAudioClip(AudioClip _newClip)
    {
        _audioSource.clip = _newClip;
    }
    private void PlayAudio()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.pitch = Random.Range(0.7f, 1.3f);
            _audioSource.Play();
        }
        else
        {
            _subSource.clip = _audioSource.clip;
            _subSource.pitch = Random.Range(0.9f, 1.1f);
            _subSource.Play();
        }
    }
    public void PlayClip(int _id)
    {
        ChangeAudioClip(_sounds[_id]);
        PlayAudio();
    }
}
