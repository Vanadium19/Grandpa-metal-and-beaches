using System.Collections.Generic;
using UnityEngine;

internal class RandomSoundPlayer : SoundPlayer
{
    [SerializeField] private List<AudioClip> _audioClips;

    public override void Play()
    {
        Source.Stop();
        Source.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Count)]);
    }
}