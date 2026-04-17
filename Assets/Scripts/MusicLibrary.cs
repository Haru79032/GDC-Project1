using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu]
public class MusicLibrary : ScriptableObject {
    [System.Serializable]
    public struct MusicMapping {
        public MusicType type;
        public AudioClip clip;
    }

    public List<MusicMapping> musicList;
    private Dictionary<MusicType, AudioClip> _dictionary;

    public void Initialize() {
        _dictionary = new Dictionary<MusicType, AudioClip>();
        foreach (var mapping in musicList) {
            _dictionary[mapping.type] = mapping.clip;
        }
    }

    public AudioClip GetClip(MusicType type) {
        return _dictionary.TryGetValue(type, out var clip) ? clip : null;
    }
}