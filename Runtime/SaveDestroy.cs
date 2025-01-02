#if Odin && UltEvent
using System;
using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;
using PlayerPrefs = PlayerPrefsWrapper;

namespace Utilities
{
    public class SaveDestroy : MonoBehaviour
    {
        [SerializeField]
        private UltEvent onDestroy;

        [SerializeField, ReadOnly]
        private SerializableGuid guid = Guid.NewGuid();

        private string KeyPath => "Save destroyed ID:" + guid.value;

        void Awake()
        {
            bool destroy = PlayerPrefs.GetBool(KeyPath);
            if (destroy)
                Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (!gameObject.scene.isLoaded)
                return;

            onDestroy?.Invoke();
            PlayerPrefs.SetBool(KeyPath, true);
        }
    }

    [Serializable]
    public struct SerializableGuid : IComparable, IComparable<SerializableGuid>, IEquatable<SerializableGuid>
    {
        public string value;

        private SerializableGuid(string value)
        {
            this.value = value;
        }

        public static implicit operator SerializableGuid(Guid guid)
        {
            return new SerializableGuid(guid.ToString());
        }

        public static implicit operator Guid(SerializableGuid serializableGuid)
        {
            return new Guid(serializableGuid.value);
        }

        public int CompareTo(object pValue)
        {
            if (pValue == null)
                return 1;
            if (pValue is not SerializableGuid guid)
                throw new ArgumentException("Must be SerializableGuid");
            return guid.value == this.value ? 0 : 1;
        }

        public int CompareTo(SerializableGuid other)
        {
            return other.value == value ? 0 : 1;
        }

        public bool Equals(SerializableGuid other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return value != null ? value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return value != null ? new Guid(value).ToString() : string.Empty;
        }
    }
}
#endif