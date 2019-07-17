using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class BowlingColorLoader : MonoBehaviour {

	public static void GetBallColor(RaycastHit rayHit, MLInputController controller, GameObject ballMenu, bool ballMenuOpened, bool holdingBallMenu, GameObject bowlingBall, Material[] ballMats) {
		if (rayHit.transform.gameObject.name == "0 RedBall") {
			if (controller.TriggerValue >= 0.9f) {
				PlayerPrefs.SetInt ("ballColorInt", 0);
				ballMenu.SetActive (false);
				ballMenuOpened = false;
				holdingBallMenu = true;
				LoadBallColor(bowlingBall, ballMats);
			}
		} else if (rayHit.transform.gameObject.name == "1 OrangeBall" && controller.TriggerValue >= 0.9f) {
					PlayerPrefs.SetInt ("ballColorInt", 1);
					ballMenu.SetActive (false);
					ballMenuOpened = false;
					holdingBallMenu = true;
					LoadBallColor(bowlingBall, ballMats);
		} else if (rayHit.transform.gameObject.name == "2 YellowBall" && controller.TriggerValue >= 0.9f) {
					PlayerPrefs.SetInt ("ballColorInt", 2);
					ballMenu.SetActive (false);
					ballMenuOpened = false;
					holdingBallMenu = true;
					LoadBallColor(bowlingBall, ballMats);
		} else if (rayHit.transform.gameObject.name == "3 GreenBall" && controller.TriggerValue >= 0.9f) {
					PlayerPrefs.SetInt ("ballColorInt", 3);
					ballMenu.SetActive (false);
					ballMenuOpened = false;
					holdingBallMenu = true;
					LoadBallColor(bowlingBall, ballMats);
		} else if (rayHit.transform.gameObject.name == "4 BlueBall" && controller.TriggerValue >= 0.9f) {
					PlayerPrefs.SetInt ("ballColorInt", 4);
					ballMenu.SetActive (false);
					ballMenuOpened = false;
					holdingBallMenu = true;
					LoadBallColor(bowlingBall, ballMats);
		}
	}
	public static void LoadBallColor (GameObject bowlingBall, Material[] ballMats) {
		Transform ballObject = bowlingBall.transform.GetChild (0);
		Renderer ballRender = ballObject.GetComponent<Renderer> ();
		int savedBallColor = PlayerPrefs.GetInt ("ballColorInt", 2);
		if (savedBallColor >= 0 && savedBallColor <= 4) {
			ballRender.material = ballMats[savedBallColor];
		} else {
			ballRender.material = ballMats[0];
		}

	}

}
