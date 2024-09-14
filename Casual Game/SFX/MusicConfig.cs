using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MusicConfig", menuName = "Rainbow/MusicConfig", order = 100)]
public class MusicConfig : ScriptableObject
{
    public List<Music> sounds;
}
