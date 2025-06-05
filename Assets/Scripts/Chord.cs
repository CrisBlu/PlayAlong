using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ChordData", menuName = "ScriptableObjects/NewChord")]
public class Chord : ScriptableObject
{
    public List<string> chord = new List<string>() { "E", "F", "F#", "G", "G#", "A", "A#", "B", "C", "C#", "D", "D#", "E" };


}
