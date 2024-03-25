using UnityEngine;

public class FiveThings : MonoBehaviour
{
    public GameObject[] Things;
    public GameObject door;
    public AudioSource DoorOpenSound;

    void Update()
    {
        bool allcollected = true;

        foreach (GameObject thing in Things)
        {
            if (thing.activeSelf)
            {
                allcollected = false;
                break;
            }
        }

        if (allcollected)
        {
            door.SetActive(false);
            DoorOpenSound.Play();
        }
        else
        {
            door.SetActive(true);
        }
    }
}
