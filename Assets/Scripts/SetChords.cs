using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetChords
{
    /*private List<Chord> chords;
    private int index = 0;

    void OnEnable()
    {
        
    }

    ///Compare notes from arrays with names of the note game objects; highlight the applicable notes; maybe do a blue outline?
   
    public void SetScale()
    { 
        if (chords == null)
        {
            index++;
            index %= chords.Count;
            Debug.Log(chords[index]);
        }
    }

    public void addChord(Chord chord)
    {
        chords.Add(chord);
    }*/

    //turn off note if not found
    public void HighlightNotes(GameObject[] allNotes, Chord scale)
    {
       
        foreach (GameObject note in allNotes) 
        {
            bool inScale = false;

            foreach (string scaleNote in scale.chord)
            {
                if(note.name == scaleNote)
                {
                    note.GetComponent<PlayNote>().Highlight();
                    inScale = true;
                }

            }

            if (!inScale)
            {
                note.GetComponent<PlayNote>().UnHighlight();
            }
            

        }
    }
}
