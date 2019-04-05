using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource EffectsSourceBackup; //use this if a sound is already playing, so there's no quick cutoff
    public AudioClip SelectClip;
    public AudioClip SubmitClip;
    public AudioClip ErrorResolvedClip;
    public AudioClip HoverClip;
    public AudioClip PassiveClip; //for when a UI element is enabled despite no player input
    public AudioClip CoffeeClip;
    public AudioClip BathroomClip; // hot chocolate high velocity
    public AudioClip SleepClip;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    // Play a single clip with optional pitch shifting
    public void Play(AudioClip clip, bool pitchShift = false)
    {
        // So we avoid sound cutoff (slamming selections is really jarring)
        if (!EffectsSource.isPlaying)
        {
            if (pitchShift)
                EffectsSource.pitch = RandomizePitch();

            EffectsSource.clip = clip;
            EffectsSource.Play();
        }
        else
        {
            if(pitchShift)
                EffectsSourceBackup.pitch = RandomizePitch();

            EffectsSourceBackup.clip = clip;
            EffectsSourceBackup.Play();
        }
    }

    public void PitchShiftSelectionEffect()
    {
        Play(SelectClip, true);
    }

    public void PitchShiftSubmitEffect()
    {
        Play(SubmitClip, true);
    }

    public void ErrorResolved()
    {
        Play(ErrorResolvedClip);
    }

    public void ItemHighlighted()
    {
        Play(HoverClip);
    }

    public void PassiveEnabled()
    {
        Play(PassiveClip, true);
    }

    public void CoffeeDrank()
    {
        Play(CoffeeClip, true);
    }

    public void BathroomTime()
    {
        Play(BathroomClip);
    }

    public void SleepTime()
    {
        Play(SleepClip);
    }

    private float RandomizePitch()
    {
        return Random.Range(LowPitchRange, HighPitchRange);
    }
}
