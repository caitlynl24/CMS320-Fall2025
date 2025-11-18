using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        // Make sure only ONE MusicManager exists
        GameObject[] managers = GameObject.FindGameObjectsWithTag("Music");

        if (managers.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
