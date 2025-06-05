using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] List<Chord> chords;
    [SerializeField] private List<GameObject> notes;
    [SerializeField] private TextMeshPro currentChordDisplay;
    [SerializeField] private TextMeshPro currentScaleDisplay;
    private string[] playedPowerChords = new string[] { "E", "A", "B", "E" };
    private int chordIndex = 0;
    private int scaleIndex = 0;
    SetChords SetChords = new SetChords();

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    [SerializeField] private float songBpm;

    //The number of seconds for each song beat
    private float secPerBeat;

    //Current song position, in seconds
    private float songPosition;

    //Current song position, in beats
    private float songPositionInBeats;

    //How many seconds have passed since the song started
    private float dspSongTime;

    private bool chordChangeLocked = false;

    //an AudioSource attached to this GameObject that will play the music.
    private AudioSource musicSource;

    //My voice overs
    [SerializeField] private AudioClip[] audioClips;


    // Thank you to Graham Tattersall and his article "Coding to the Beat" for the beat keeping part of this code
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        SetChords.HighlightNotes(notes.ToArray(), chords[0]);
    }

    public void NextScale(int next)
    {
        scaleIndex += next;
        scaleIndex %= chords.ToArray().Length;
        currentScaleDisplay.text = chords[scaleIndex].name;
        SetChords.HighlightNotes(notes.ToArray(), chords[scaleIndex]);
    }

    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        float twoMeasureBeatKeeper = songPositionInBeats % 8;

        if (twoMeasureBeatKeeper <= .1f && !chordChangeLocked)
        {
            //Lock the chord to where it is the first time a change is detected
            chordIndex++;
            chordIndex %= playedPowerChords.Length;
            currentChordDisplay.text = playedPowerChords[chordIndex];
            chordChangeLocked = true;
        }
        else if (twoMeasureBeatKeeper > .1 && chordChangeLocked)
        {
            //Only unlock it if we know the chord should 100% not change here and is locked
            chordChangeLocked = false;
        }
    }

}
