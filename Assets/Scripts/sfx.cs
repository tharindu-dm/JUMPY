using UnityEngine;

public class sfx : MonoBehaviour
{
    public AudioSource engineStart;
    public AudioSource engineOngoing;

    void Start()
    {
        engineStart.Play();
        engineOngoing.Play();
    }
}
