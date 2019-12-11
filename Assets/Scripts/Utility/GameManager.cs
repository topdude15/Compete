using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.MagicLeap;
using MagicLeapTools;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Pointer pointer;
    [SerializeField] private GameObject mainMenu, privacyPolicyMenu, quitMenu;

    void Start()
    {
        MLInput.Start();
        MLInput.OnTriggerDown += OnTriggerDown;
        MLInput.TriggerDownThreshold = 0.75f;

    }
    private void OnTriggerDown(byte controller_Id, float triggerValue)
    {
        string objGameHit = pointer.Target.gameObject.name;
        switch (objGameHit)
        {
            case "BowlingPin":
                SceneManager.LoadScene("BowlingMultiplayer", LoadSceneMode.Single);
                break;
            case "Dartboard":
                SceneManager.LoadScene("DartsMultiplayer", LoadSceneMode.Single);
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
				// No GameObject selected
				break;
        }
    }
}
