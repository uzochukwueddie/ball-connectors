using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBG : MonoBehaviour {

	public Sprite[] Backgrounds;
 
    private SpriteRenderer Render;

	private SVGImage svg;

	private int index;
 
    void Start () {
		svg = GetComponent<SVGImage>();
		index = PlayerPrefs.GetInt("BgNumber");
		svg.sprite = Backgrounds[index];
	}
}
