using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject HUDTitle;
    [SerializeField]
    GameObject HUDMainButtons;
    [SerializeField]
    GameObject HUDAbout;
    [SerializeField]
    GameObject HUDFullTest;
    [SerializeField]
    GameObject HUDFlashTest;
    [SerializeField]
    GameObject HUDTimeTest;
    [SerializeField]
    GameObject HUDStudy;
    [SerializeField]
    GameObject HUDStudyRoots;
    [SerializeField]
    GameObject HUDStudyAsanas;

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
        HUDMainButtons.GetComponent<MoveNormal>().MoveLeft();
        HUDAbout.GetComponent<MoveNormal>().MoveLeft();
    }

    public void SelectAboutBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDAbout.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectFullTestButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveLeft();
        HUDFullTest.GetComponent<MoveNormal>().MoveLeft();
    }
    public void SelectFullTestBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDFullTest.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectFlashTestButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveLeft();
        HUDFlashTest.GetComponent<MoveNormal>().MoveLeft();
    }
    public void SelectFlashTestBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDFlashTest.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectTimeAttackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveLeft();
        HUDTimeTest.GetComponent<MoveNormal>().MoveLeft();
    }
    public void SelectTimeAttackBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDTimeTest.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectStudyButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveLeft();
        HUDStudy.GetComponent<MoveNormal>().MoveLeft();
    }
    public void SelectStudyBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDStudy.GetComponent<MoveNormal>().MoveRight();
    }
    public void SelectStudyRootsButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDStudy.GetComponent<MoveNormal>().MoveDown();
        HUDTitle.GetComponent<MoveNormal>().MoveDown();
        HUDStudyRoots.GetComponent<MoveNormal>().MoveUp();
    }
    public void SelectStudyRootsBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDStudy.GetComponent<MoveNormal>().MoveUp();
        HUDTitle.GetComponent<MoveNormal>().MoveUp();
        HUDStudyRoots.GetComponent<MoveNormal>().MoveDown();
    }
    public void SelectStudyAsanasButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDStudy.GetComponent<MoveNormal>().MoveDown();
        HUDTitle.GetComponent<MoveNormal>().MoveDown();
        HUDStudyAsanas.GetComponent<MoveNormal>().MoveUp();
    }
    public void SelectStudyAsanasBackButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDStudy.GetComponent<MoveNormal>().MoveUp();
        HUDTitle.GetComponent<MoveNormal>().MoveUp();
        HUDStudyAsanas.GetComponent<MoveNormal>().MoveDown();
    }
}
