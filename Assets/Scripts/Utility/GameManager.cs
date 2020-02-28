#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.MagicLeap;
using MagicLeapTools;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Pointer pointer;
    [SerializeField] private AudioSource menuAudio;
    [SerializeField] private GameObject mainMenu, privacyPolicyMenu, quitMenu, mainCam;

    void Start()
    {
        MLInput.Start();
        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.TriggerDownThreshold = 0.75f;

    }
    private void OnDestroy() {
        MLInput.OnTriggerDown -= OnTriggerDown;
    }
    private void OnTriggerDown(byte controller_Id, float triggerValue)
    {
        string objGameHit = pointer.Target.gameObject.name;
        if (objGameHit != null) menuAudio.Play();
        switch (objGameHit)
        {
            case "BowlingPin":
                SceneManager.LoadScene("BowlingMultiplayer", LoadSceneMode.Single);
                SceneManager.UnloadSceneAsync("Main");
                break;
            case "Dartboard":
                SceneManager.LoadScene("DartsMultiplayer", LoadSceneMode.Single);
                SceneManager.UnloadSceneAsync("Main");
                break;
            case "PrivacyPolicy":
                mainMenu.SetActive(false);
                privacyPolicyMenu.SetActive(true);
                break;
            case "ClosePrivacyPolicy":
                mainMenu.SetActive(true);
                privacyPolicyMenu.SetActive(false);
                break;
            case "ExitGame":
                quitMenu.SetActive(true);
                mainMenu.SetActive(false);
                break;
            case "ConfirmExit":
                Application.Quit();
                break;
            case "StayInGame":
                quitMenu.SetActive(false);
                mainMenu.SetActive(true);
                break;
			default:
				break;
        }
    }
}
