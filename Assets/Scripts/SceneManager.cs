using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    // study HUD elements
    [SerializeField]
    GameObject HUDStudy;
    [SerializeField]
    GameObject HUDStudyRoots;
    [SerializeField]
    GameObject HUDStudyAsanas;
    [SerializeField]
    Image HUDStudyImage;
    [SerializeField]
    TextMeshProUGUI HUDStudyEngName;
    [SerializeField]
    TextMeshProUGUI HUDStudySansName;
    [SerializeField]
    TextMeshProUGUI HUDStudyCat;
    [SerializeField]
    TextMeshProUGUI HUDStudyNum;

    // quiz HUD elements
    [SerializeField]
    GameObject HUDQuiz;
    [SerializeField]
    GameObject HUDQuizDone;

    [SerializeField]
    GameObject HUDQuizCorrectBar;
    [SerializeField]
    GameObject HUDQuizIncorrectBar;
    [SerializeField]
    GameObject HUDQuizCorrect;
    [SerializeField]
    GameObject HUDQuizIncorrect;
    [SerializeField]
    GameObject HUDQuizCorrectTime;
    [SerializeField]
    GameObject HUDQuizIncorrectTime;
    [SerializeField]
    GameObject HUDQuizCurrentScore;
    [SerializeField]
    GameObject HUDQuizCurrentTime;
    [SerializeField]
    GameObject[] HUDQuizAnswerButtons;
    [SerializeField]
    GameObject[] HUDQuizCatAnswerButtons;
    [SerializeField]
    GameObject HUDQuizPose;
    [SerializeField]
    GameObject HUDQuizPoseBorder;
    [SerializeField]
    GameObject HUDQuizCatPose;
    [SerializeField]
    GameObject HUDQuizCatPoseBorder;
    [SerializeField]
    GameObject HUDQuizEnglishNameText;
    [SerializeField]
    GameObject HUDQuizSanskritNameText;
    [SerializeField]
    GameObject HUDQuizCatBox;
    [SerializeField]
    GameObject HUDQuizCatBoxBorder;
    [SerializeField]
    GameObject HUDQuizCategoryText;
    [SerializeField]
    GameObject HUDNextButton;

    [SerializeField]
    TextMeshProUGUI HUDFinalScore;
    [SerializeField]
    TextMeshProUGUI HUDFinalPercent;

    AudioSource audioSource;
    [SerializeField]
    AudioClip MenuSound;
    [SerializeField]
    AudioClip CorrectSound;
    [SerializeField]
    AudioClip IncorrectSound;

    List<Asana> asanas = new List<Asana>();
    [SerializeField]
    Sprite[] AsanaSprites = new Sprite[75];

    int[] quizAnswers;
    int currentQuizQuestionNum = -1;
    int currentQuizAnswerIndex = 0;
    int maxFlashQuizQuestions = 30;
    int currentQuestionsCorrect = 0;
    int currentQuestionsComplete = 0;

    int currentStudyIndex = 0;

    enum QuizType {
        Full,
        Flash,
        Time
    }
    QuizType currentQuizType;
    enum QuizContent {
        English,
        Sanskrit,
        Category,
    }
    QuizContent currentQuizContent;
    float quizTimer = 0f;
    float quizScoreTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        CreateAsanaList();
        UpdateStudyAsana();
    }

    void CreateAsanaList()
    {
        asanas.Add(new Asana("Hero's Pose", "Virasana", "Seated Pose", AsanaSprites[0]));
        asanas.Add(new Asana("Diamond Pose", "Vajrasana", "Seated Pose", AsanaSprites[1]));
        asanas.Add(new Asana("Easy Pose", "Sukhasana", "Seated Pose", AsanaSprites[2]));
        asanas.Add(new Asana("Lotus Pose", "Padmasana", "Seated Pose", AsanaSprites[3]));
        asanas.Add(new Asana("Mountain Pose", "Tadasana", "Standing Pose", AsanaSprites[4]));
        asanas.Add(new Asana("Standing Forward Bend", "Uttanasana", "Standing Pose", AsanaSprites[5]));
        asanas.Add(new Asana("Upward Salute", "Urdhva Hastasana", "Standing Pose", AsanaSprites[6]));
        asanas.Add(new Asana("Chair/Fierce Pose", "Utkatasana", "Standing Pose", AsanaSprites[7]));
        asanas.Add(new Asana("Warrior II", "Virabhadrasana II", "Standing Pose", AsanaSprites[8]));
        asanas.Add(new Asana("Side Angle Pose", "Utthita Parsvakonasana", "Standing Pose", AsanaSprites[9]));
        asanas.Add(new Asana("Triangle Pose", "Utthita Trikonasana", "Standing Pose", AsanaSprites[10]));
        asanas.Add(new Asana("Half Moon Pose", "Ardha Chandrasana", "Standing Pose", AsanaSprites[11]));
        asanas.Add(new Asana("Warrior I", "Virabhadrasana I", "Standing Pose", AsanaSprites[12]));
        asanas.Add(new Asana("Revolved Side Angle", "Parivrtta Parsvakonasana", "Standing Pose", AsanaSprites[13]));
        asanas.Add(new Asana("Wide Legged Forward Bend", "Prasarita Padottanasana", "Standing Pose", AsanaSprites[14]));
        asanas.Add(new Asana("Pyramid", "Parsvottanasana", "Standing Pose", AsanaSprites[15]));
        asanas.Add(new Asana("Revolved Triangle Pose", "Parivrtta Trikonasana", "Standing Pose", AsanaSprites[16]));
        asanas.Add(new Asana("Warrior III", "Virabhadrasana III", "Standing Pose", AsanaSprites[17]));
        asanas.Add(new Asana("Revolved Half Moon", "Parivrtta Ardha Chandrasana", "Standing Pose", AsanaSprites[18]));
        asanas.Add(new Asana("Standing Splits", "Urdhva Prasarita Eka Padasana", "Standing Pose", AsanaSprites[19]));
        asanas.Add(new Asana("Tree Pose", "Vrksasana", "Standing Pose", AsanaSprites[20]));
        asanas.Add(new Asana("Eagle Pose", "Garudasana", "Standing Pose", AsanaSprites[21]));
        asanas.Add(new Asana("Dancer's Pose", "Natarajasana", "Standing Pose", AsanaSprites[22]));
        asanas.Add(new Asana("Boat Pose", "Navasana", "Abdominal", AsanaSprites[23]));
        asanas.Add(new Asana("Half Boat Pose", "Ardha NavasanaMalasana", "Abdominal", AsanaSprites[24]));
        asanas.Add(new Asana("Squat", "Malasana", "Seated Pose", AsanaSprites[25]));
        asanas.Add(new Asana("Child's Pose", "Balasana", "Seated Pose", AsanaSprites[26]));
        asanas.Add(new Asana("Staff Pose", "Dandasana", "Seated Pose", AsanaSprites[27]));
        asanas.Add(new Asana("Seated Forward Bend", "Paschimottanasana", "Seated Pose", AsanaSprites[28]));
        asanas.Add(new Asana("Reverse Table Top", "Purvottanasana", "Backbend", AsanaSprites[29]));
        asanas.Add(new Asana("Head to Knee", "Janu Sirsasana", "Seated Pose", AsanaSprites[30]));
        asanas.Add(new Asana("Revolved Head to Toe", "Parivrtta Janu Sirsasana", "Seated Pose", AsanaSprites[31]));
        asanas.Add(new Asana("Bound Angle Pose", "Baddha Konasana", "Seated Pose", AsanaSprites[32]));
        asanas.Add(new Asana("Cow Face Pose", "Gomukhasana", "Seated Pose", AsanaSprites[33]));
        asanas.Add(new Asana("Wide Angle Seated Forward Bend", "Upavistha Konasana", "Seated Pose", AsanaSprites[34]));
        asanas.Add(new Asana("Sage Marichi Pose", "Marichyasana", "Seated Pose", AsanaSprites[35]));
        asanas.Add(new Asana("One Leg King Pigeon", "Eka Pada Rajakapotasana", "Seated Pose", AsanaSprites[36]));
        asanas.Add(new Asana("Abdomen Turning Pose", "Jathara Parivartanasana", "Seated Pose", AsanaSprites[37]));
        asanas.Add(new Asana("Sage Marichi III Pose", "Marichyasana III", "Seated Pose", AsanaSprites[38]));
        asanas.Add(new Asana("Sage Bharadvaja's Pose", "Bharadvajasana", "Seated Pose", AsanaSprites[39]));
        asanas.Add(new Asana("Half Sage Matsyendra's Pose", "Ardha Matsyendrasana", "Seated Pose", AsanaSprites[40]));
        asanas.Add(new Asana("Cobra Pose", "Bhujangasana", "Backbend", AsanaSprites[41]));
        asanas.Add(new Asana("Locust Pose", "Salabhasana", "Backbend", AsanaSprites[42]));
        asanas.Add(new Asana("Bow Pose", "Dhanurasana", "Backbend", AsanaSprites[43]));
        asanas.Add(new Asana("Upward Facing Dog", "Urdhva Mukha Svanasana", "Backbend", AsanaSprites[44]));
        asanas.Add(new Asana("Camel Pose", "Ustrasana", "Backbend", AsanaSprites[45]));
        asanas.Add(new Asana("Bridge Pose", "Setu Bandha Sarvangasana", "Backbend", AsanaSprites[46]));
        asanas.Add(new Asana("Upward Bow", "Urdhva Dhanurasana", "Backbend", AsanaSprites[47]));
        asanas.Add(new Asana("Fish Pose", "Matsyasana", "Backbend", AsanaSprites[48]));
        asanas.Add(new Asana("Plank Pose", "Santolasana", "Arm Balance", AsanaSprites[49]));
        asanas.Add(new Asana("Side Plank", "Vasisthasana", "Arm Balance", AsanaSprites[50]));
        asanas.Add(new Asana("Bottom of Plank", "Chaturanga Dandasana", "Arm Balance", AsanaSprites[51]));
        asanas.Add(new Asana("Crow", "Bakasana", "Arm Balance", AsanaSprites[52]));
        asanas.Add(new Asana("Forearm Plank", "Makara Adho Mukha Svanasana", "Arm Balance", AsanaSprites[53]));
        asanas.Add(new Asana("Downward Facing Dog", "Adho Mukha Svanasana", "Arm Balance", AsanaSprites[54]));
        asanas.Add(new Asana("Dolphin Dog", "Ardha Pincha Mayurasana", "Arm Balance", AsanaSprites[55]));
        asanas.Add(new Asana("Forearm Balance", "Pincha Mayurasana", "Arm Balance", AsanaSprites[56]));
        asanas.Add(new Asana("Handstand", "Adho Mukha Vrikshasana", "Arm Balance", AsanaSprites[57]));
        asanas.Add(new Asana("Headstand", "Sirsasana", "Inversion", AsanaSprites[58]));
        asanas.Add(new Asana("Shoulder Stand", "Salamba Sarvangasana", "Inversion", AsanaSprites[59]));
        asanas.Add(new Asana("Plow Pose", "Halasana", "Inversion", AsanaSprites[60]));
        asanas.Add(new Asana("Legs Up Wall", "Viparita Karani", "Inversion", AsanaSprites[61]));
        asanas.Add(new Asana("Knees to Chest", "Apanasana", "Supine Pose", AsanaSprites[62]));
        asanas.Add(new Asana("Reclining Bound Angle", "Supta Baddha Konasana", "Supine Pose", AsanaSprites[63]));
        asanas.Add(new Asana("Reclined Hand to Toe", "Supta Padangusthasana", "Supine Pose", AsanaSprites[64]));
        asanas.Add(new Asana("Happy Baby", "Ananda Balasana", "Supine Pose", AsanaSprites[65]));
        asanas.Add(new Asana("Corpse Pose", "Savasana", "Supine Pose", AsanaSprites[66]));
        asanas.Add(new Asana("Lunge", "Anjaneyasana", "Standing Pose", AsanaSprites[67]));
        asanas.Add(new Asana("Eight Angle Pose", "Astavakrasana", "Arm Balance", AsanaSprites[68]));
        asanas.Add(new Asana("Firefly", "Tittibhasana", "Arm Balance", AsanaSprites[69]));
        asanas.Add(new Asana("Peacock", "Mayurasana", "Arm Balance", AsanaSprites[70]));
        asanas.Add(new Asana("Sage Koundinya Pose I", "Eka Pada Koundinyasana I", "Arm Balance", AsanaSprites[71]));
        asanas.Add(new Asana("Sage Koundinya Pose II", "Eka Pada Koundinyasana II", "Arm Balance", AsanaSprites[72]));
        asanas.Add(new Asana("Side Crow", "Parsva Bakasana", "Arm Balance", AsanaSprites[73]));
        asanas.Add(new Asana("Wild Thing", "Camatkarasana", "Arm Balance", AsanaSprites[74]));

        quizAnswers = new int[asanas.Count];
        for (int i = 0; i < quizAnswers.Length; i++)
        {
            quizAnswers[i] = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (quizTimer > 0)
        {
            quizTimer -= Time.deltaTime;
            float displayTime = Mathf.Max(0, quizTimer);
            HUDQuizCurrentTime.GetComponent<TextMeshProUGUI>().text = displayTime.ToString("F2");
            if (quizTimer <= 0)
            {
                QuizComplete();
            }
        }
        if (quizScoreTimer > 0)
        {
            quizScoreTimer -= Time.deltaTime;
            if (quizScoreTimer <= 0)
            {
                HUDQuizCorrectTime.SetActive(false);
                HUDQuizIncorrectTime.SetActive(false);
            }
        }
    }

    void UpdateStudyAsana()
    {
        HUDStudyImage.sprite = asanas[currentStudyIndex].ImageSprite;
        HUDStudyEngName.text = asanas[currentStudyIndex].EnglishName;
        HUDStudySansName.text = asanas[currentStudyIndex].SanskritName;
        HUDStudyCat.text = asanas[currentStudyIndex].Category;
        HUDStudyNum.text = (currentStudyIndex + 1) + " of " + asanas.Count;
    }

    void StartQuiz()
    {
        currentQuestionsComplete = 0;
        currentQuestionsCorrect = 0;

        HUDFullTest.GetComponent<MoveNormal>().MoveDown();
        HUDFlashTest.GetComponent<MoveNormal>().MoveDown();
        HUDTimeTest.GetComponent<MoveNormal>().MoveDown();
        HUDTitle.GetComponent<MoveNormal>().MoveDown();
        HUDQuiz.GetComponent<MoveNormal>().MoveUp();

        HUDQuizCorrectBar.SetActive(false);
        HUDQuizIncorrectBar.SetActive(false);
        HUDQuizCorrect.SetActive(false);
        HUDQuizIncorrect.SetActive(false);
        HUDQuizCorrectTime.SetActive(false);
        HUDQuizIncorrectTime.SetActive(false);
        HUDQuizCurrentScore.SetActive(false);
        HUDQuizCurrentTime.SetActive(currentQuizType == QuizType.Time);
        HUDQuizPose.SetActive(currentQuizContent != QuizContent.Category);
        HUDQuizPoseBorder.SetActive(currentQuizContent != QuizContent.Category);
        HUDQuizCatPose.SetActive(false);
        HUDQuizCatPoseBorder.SetActive(false);
        HUDQuizEnglishNameText.SetActive(false);
        HUDQuizSanskritNameText.SetActive(false);
        HUDQuizCategoryText.SetActive(currentQuizContent == QuizContent.Category);
        HUDQuizCatBox.SetActive(currentQuizContent == QuizContent.Category);
        HUDQuizCatBoxBorder.SetActive(currentQuizContent == QuizContent.Category);
        HUDNextButton.SetActive(false);

        for (int i = 0; i < HUDQuizAnswerButtons.Length; i++)
        {
            HUDQuizAnswerButtons[i].SetActive(currentQuizContent != QuizContent.Category);
        }
        for (int i = 0; i < HUDQuizCatAnswerButtons.Length; i++)
        {
            HUDQuizCatAnswerButtons[i].SetActive(currentQuizContent == QuizContent.Category);
        }

        PrepareQuizQuestions();
        ShowNextQuizQuestion();
        if (currentQuizType == QuizType.Time)
            quizTimer = 30f;
    }

    public void PrepareQuizQuestions()
    {
        // Knuth shuffle algorithm
        for (int i = 0; i < quizAnswers.Length; i++ )
        {
            int tmp = quizAnswers[i];
            int r = Random.Range(i, quizAnswers.Length);
            quizAnswers[i] = quizAnswers[r];
            quizAnswers[r] = tmp;
        }
        currentQuizQuestionNum = -1;
    }

    public void ShowNextQuizQuestion()
    {
        // is the quiz over
        if (currentQuizType == QuizType.Flash && currentQuestionsComplete == maxFlashQuizQuestions)
        {
            QuizComplete();
            return;
        }
        else if (currentQuizType == QuizType.Full && currentQuestionsComplete == asanas.Count)
        {
            QuizComplete();
            return;
        }

        currentQuizQuestionNum++;

        if (currentQuizQuestionNum >= asanas.Count)
            currentQuizQuestionNum = 0;

        int poseIndex = quizAnswers[currentQuizQuestionNum];
        if (currentQuizContent != QuizContent.Category)
        {
            // show a pose image and 4 pose buttons
            HUDQuizPose.GetComponent<Image>().sprite = asanas[poseIndex].ImageSprite;
            currentQuizAnswerIndex = Random.Range(0, 4);
            int[] answerPoseIndices = new int[4];
            for (int i = 0; i < answerPoseIndices.Length; i++)
            {
                answerPoseIndices[i] = -1;
            }
            answerPoseIndices[currentQuizAnswerIndex] = poseIndex;
            int x = 0;
            do {
                if (x == currentQuizAnswerIndex)
                {
                    x++;
                }
                else
                {
                    int potentialPoseIndex = Random.Range(0, asanas.Count);
                    bool alreadyUsed = false;
                    for (int i = 0; i < answerPoseIndices.Length; i++)
                    {
                        if (answerPoseIndices[i] == potentialPoseIndex)
                            alreadyUsed = true;
                    }
                    if (!alreadyUsed)
                    {
                        answerPoseIndices[x] = potentialPoseIndex;
                        x++;
                    }
                }
            } while (x < answerPoseIndices.Length);

            for (int i = 0; i < HUDQuizAnswerButtons.Length; i++)
            {
                HUDQuizAnswerButtons[i].SetActive(true);
                HUDQuizAnswerButtons[i].transform.Find("AnswerText").gameObject.GetComponent<TextMeshProUGUI>().text = currentQuizContent == QuizContent.English
                    ? asanas[answerPoseIndices[i]].EnglishName
                    : asanas[answerPoseIndices[i]].SanskritName;
            }
        }
        else
        {
            // show pose text and 7 cat buttons
            HUDQuizCategoryText.GetComponent<TextMeshProUGUI>().text = asanas[poseIndex].EnglishName + "\n\n"+ asanas[poseIndex].SanskritName;
            if (asanas[poseIndex].Category == "Standing Pose")
                currentQuizAnswerIndex = 0;
            else if (asanas[poseIndex].Category == "Seated Pose")
                currentQuizAnswerIndex = 1;
            else if (asanas[poseIndex].Category == "Inversion")
                currentQuizAnswerIndex = 2;
            else if (asanas[poseIndex].Category == "Arm Balance")
                currentQuizAnswerIndex = 3;
            else if (asanas[poseIndex].Category == "Backbend")
                currentQuizAnswerIndex = 4;
            else if (asanas[poseIndex].Category == "Supine Pose")
                currentQuizAnswerIndex = 5;
            else if (asanas[poseIndex].Category == "Abdominal")
                currentQuizAnswerIndex = 6;

            for (int i = 0; i < HUDQuizCatAnswerButtons.Length; i++)
            {
                HUDQuizCatAnswerButtons[i].SetActive(true);
            }
            HUDQuizCatPose.GetComponent<Image>().sprite = asanas[poseIndex].ImageSprite;
        }

        HUDNextButton.SetActive(false);
        HUDQuizCorrectBar.SetActive(false);
        HUDQuizIncorrectBar.SetActive(false);
        HUDQuizEnglishNameText.SetActive(false);
        HUDQuizSanskritNameText.SetActive(false);
        HUDQuizCorrect.SetActive(false);
        HUDQuizIncorrect.SetActive(false);
        HUDQuizCorrect.transform.localScale = new Vector3(.1f, .1f, .1f);
        HUDQuizIncorrect.transform.localScale = new Vector3(.1f, .1f, .1f);
        HUDQuizCurrentScore.SetActive(false);
        HUDQuizCatPose.SetActive(false);
        HUDQuizCatPoseBorder.SetActive(false);
    }

    public void GradeQuizAnswer(int answerIndex)
    {
        bool correct = currentQuizAnswerIndex == answerIndex;

        HUDNextButton.SetActive(currentQuizType != QuizType.Time);
        if (currentQuizType != QuizType.Time)
        {
            for (int i = 0; i < HUDQuizAnswerButtons.Length; i++)
            {
                HUDQuizAnswerButtons[i].SetActive(false);
            }
            for (int i = 0; i < HUDQuizCatAnswerButtons.Length; i++)
            {
                HUDQuizCatAnswerButtons[i].SetActive(false);
            }
        }
        HUDQuizCorrectBar.SetActive(correct && currentQuizType != QuizType.Time);
        HUDQuizIncorrectBar.SetActive(!correct && currentQuizType != QuizType.Time);

        if (currentQuizContent != QuizContent.Category)
        {
            HUDQuizEnglishNameText.GetComponent<TextMeshProUGUI>().text = asanas[quizAnswers[currentQuizQuestionNum]].EnglishName;
            HUDQuizSanskritNameText.GetComponent<TextMeshProUGUI>().text = asanas[quizAnswers[currentQuizQuestionNum]].SanskritName;
            HUDQuizSanskritNameText.SetActive(currentQuizType != QuizType.Time);
        }
        else
        {
            HUDQuizEnglishNameText.GetComponent<TextMeshProUGUI>().text = asanas[quizAnswers[currentQuizQuestionNum]].Category;
        }
        HUDQuizEnglishNameText.SetActive(currentQuizType != QuizType.Time);
        HUDQuizCatPose.GetComponent<Image>().sprite = asanas[quizAnswers[currentQuizQuestionNum]].ImageSprite;
        HUDQuizCatPose.SetActive(currentQuizType != QuizType.Time && currentQuizContent == QuizContent.Category);
        HUDQuizCatPoseBorder.SetActive(currentQuizType != QuizType.Time && currentQuizContent == QuizContent.Category);

        HUDQuizIncorrectTime.SetActive(false);
        HUDQuizCorrectTime.SetActive(false);
        if (correct)
        {
            audioSource.PlayOneShot(CorrectSound, 1f);
            currentQuestionsCorrect++;
            HUDQuizCorrectTime.SetActive(currentQuizType == QuizType.Time);
            HUDQuizCorrect.SetActive(currentQuizType != QuizType.Time);
            if (currentQuizType == QuizType.Time)
                HUDQuizCorrectTime.GetComponent<GrowAndShrink>().StartEffect();
            else
                HUDQuizCorrect.GetComponent<GrowAndShrink>().StartEffect();
        }
        else
        {
            audioSource.PlayOneShot(IncorrectSound, 1f);
            HUDQuizIncorrectTime.SetActive(currentQuizType == QuizType.Time);
            HUDQuizIncorrect.SetActive(currentQuizType != QuizType.Time);
            if (currentQuizType == QuizType.Time)
                HUDQuizIncorrectTime.GetComponent<GrowAndShrink>().StartEffect();
            else
                HUDQuizIncorrect.GetComponent<GrowAndShrink>().StartEffect();
        }
        currentQuestionsComplete++;
        HUDQuizCurrentScore.GetComponent<TextMeshProUGUI>().text = currentQuestionsCorrect + " for " + currentQuestionsComplete;
        HUDQuizCurrentScore.SetActive(currentQuizType != QuizType.Time);
        if (currentQuizType == QuizType.Time)
        {
            quizScoreTimer = 1.5f;
            ShowNextQuizQuestion();
        }
    }

    public void QuizComplete()
    {
        HUDFinalScore.text = "You got " + currentQuestionsCorrect + " out of " + currentQuestionsComplete + " correct!";
        float percent = (float)currentQuestionsCorrect / (float)currentQuestionsComplete * 100.0f;
        HUDFinalPercent.text = percent.ToString("0") + "%";
        HUDQuiz.GetComponent<MoveNormal>().MoveDown();
        HUDQuizDone.GetComponent<MoveNormal>().MoveUp();
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
    public void SelectStudyPrevButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentStudyIndex--;
        if (currentStudyIndex < 0)
            currentStudyIndex = asanas.Count - 1;
        UpdateStudyAsana();
    }
    public void SelectStudyNextButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentStudyIndex++;
        if (currentStudyIndex >= asanas.Count)
            currentStudyIndex = 0;
        UpdateStudyAsana();
    }
    public void SelectStartFullEngQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Full;
        currentQuizContent = QuizContent.English;
        StartQuiz();
    }
    public void SelectStartFullSansQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Full;
        currentQuizContent = QuizContent.Sanskrit;
        StartQuiz();
    }
    public void SelectStartFullCatQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Full;
        currentQuizContent = QuizContent.Category;
        StartQuiz();
    }
    public void SelectStartFlashEngQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Flash;
        currentQuizContent = QuizContent.English;
        StartQuiz();
    }
    public void SelectStartFlashSansQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Flash;
        currentQuizContent = QuizContent.Sanskrit;
        StartQuiz();
    }
    public void SelectStartFlashCatQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Flash;
        currentQuizContent = QuizContent.Category;
        StartQuiz();
    }
    public void SelectStartTimeAttackQuizButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        currentQuizType = QuizType.Time;
        currentQuizContent = QuizContent.English;
        StartQuiz();
    }
    public void SelectQuizAnswerButton(int index)
    {
        GradeQuizAnswer(index);
    }
    public void SelectQuizNextButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        ShowNextQuizQuestion();
    }
    public void SelectQuizDoneButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        HUDQuizDone.GetComponent<MoveNormal>().MoveDown();
        HUDTitle.GetComponent<MoveNormal>().MoveUp();
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDFullTest.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000f, 0);
        HUDFlashTest.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000f, 0);
        HUDTimeTest.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000f, 0);
    }
    public void SelectQuizQuitButton()
    {
        audioSource.PlayOneShot(MenuSound, 1f);
        quizTimer = 0f;
        HUDQuiz.GetComponent<MoveNormal>().MoveDown();
        HUDTitle.GetComponent<MoveNormal>().MoveUp();
        HUDMainButtons.GetComponent<MoveNormal>().MoveRight();
        HUDFullTest.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000f, 0);
        HUDFlashTest.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000f, 0);
        HUDTimeTest.GetComponent<RectTransform>().anchoredPosition = new Vector2(2000f, 0);
    }

}
