using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DartColorLoader : MonoBehaviour {

	public static void GetDartColor(string objName, MLInputController controller, GameObject dartMenu, bool dartMenuOpened, bool holdingDartMenu, GameObject dart, Material[] dartMats) {
		if (objName == "RedDart") {
			if (controller.TriggerValue >= 0.9f) {
				PlayerPrefs.SetInt("dartColorInt", 0);
				dartMenu.SetActive(false);
				dartMenuOpened = false;
				holdingDartMenu = true;
				LoadDartColor(dart, dartMats);
			}
		} else if (objName == "OrangeDart") {
			if (controller.TriggerValue >= 0.9f) {
				PlayerPrefs.SetInt("dartColorInt", 1);
				dartMenu.SetActive(false);
				dartMenuOpened = false;
				holdingDartMenu = true;
				LoadDartColor(dart, dartMats);
			}
		} else if (objName == "YellowDart") {
			if (controller.TriggerValue >= 0.9f) {
				PlayerPrefs.SetInt("dartColorInt", 2);
				dartMenu.SetActive(false);
				dartMenuOpened = false;
				holdingDartMenu = true;
				LoadDartColor(dart, dartMats);
			}
		} else if (objName == "GreenDart") {
			if (controller.TriggerValue >= 0.9f) {
				PlayerPrefs.SetInt("dartColorInt", 3);
				dartMenu.SetActive(false);
				dartMenuOpened = false;
				holdingDartMenu = true;
				LoadDartColor(dart, dartMats);
			}
		} else if (objName == "BlueDart") {
			if (controller.TriggerValue >= 0.9f) {
				PlayerPrefs.SetInt("dartColorInt", 4);
				dartMenu.SetActive(false);
				dartMenuOpened = false;
				holdingDartMenu = true;
				LoadDartColor(dart, dartMats);
			}
		}
	}
	public static void LoadDartColor(GameObject dart, Material[] dartMats) {
		Transform dartObj = dart.transform.GetChild(0);
		Renderer dartRender = dartObj.GetComponent<Renderer>();
		int savedDartColor = PlayerPrefs.GetInt("dartColorInt", 0);
		print(savedDartColor);
		dartRender.material = dartMats[savedDartColor];
	}
}
