using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    private void Awake()
    {
        DontDestroyOnLoad(_object);
    }
}
