using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject HUDMainButtons;
    [SerializeField]
    GameObject HUDAbout;

    AudioSource audioSource;
    [SerializeField]
    AudioClip MenuSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectAboutButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDAbout.GetComponent<MoveNormal>().MoveLeft();
    }

    public void SelectAboutBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveLeft();
        HUDAbout.GetComponent<MoveNormal>().MoveRight();
    }
}
