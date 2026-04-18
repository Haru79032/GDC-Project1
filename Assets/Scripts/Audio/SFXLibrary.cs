using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu]
public class SFXLibrary : ScriptableObject {
    [System.Serializable]
    public struct SoundMapping {
        public SFXType type;
        public AudioClip clip;
    }

    public List<SoundMapping> soundList;
    private Dictionary<SFXType, AudioClip> _dictionary;

    public void Initialize() {
        _dictionary = new Dictionary<SFXType, AudioClip>();
        foreach (var mapping in soundList) {
            _dictionary[mapping.type] = mapping.clip;
        }
    }

    public AudioClip GetClip(SFXType type) {
        return _dictionary.TryGetValue(type, out var clip) ? clip : null;
    }
}