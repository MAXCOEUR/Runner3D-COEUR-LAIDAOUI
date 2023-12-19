using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance = null;

    public static T Instance { get { return m_instance; } }
    public static bool HasInstance { get { return m_instance != null; } }

    protected virtual void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogError($"Already an instance of {GetType().Name} existing. Destroying it.");
            Destroy(gameObject);
            return;
        }
        m_instance = this as T;
    }
}