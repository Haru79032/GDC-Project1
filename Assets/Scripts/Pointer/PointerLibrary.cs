using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu]
public class PointerLibrary : ScriptableObject {
    [System.Serializable]
    public struct PointerMapping {
        public PointerType type;
        public Sprite sprite;
    }

    public List<PointerMapping> pointerList;
    private Dictionary<PointerType, Sprite> _dictionary;

    public void Initialize() {
        _dictionary = new Dictionary<PointerType, Sprite>();
        foreach (var mapping in pointerList) {
            _dictionary[mapping.type] = mapping.sprite;
        }
    }

    public Sprite GetPointer(PointerType type) {
        return _dictionary.TryGetValue(type, out var clip) ? clip : null;
    }
}
