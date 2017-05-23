using UnityEngine;
using UnityEngine.UI;

// Changes UI slider text.
public class SliderText : MonoBehaviour {

    // The value displayed next to the slider
	Text textComponent;

	void Start() {
		textComponent = GetComponent<Text>();
		SetSliderValue(1);
	}

	public void SetSliderValue(float sliderValue) {
		textComponent.text = Mathf.Round(sliderValue).ToString();
	}
}
