using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {

	public Sprite[] Backgrounds;
 
    private SpriteRenderer render;

	private int index;
 
     // Use this for initialization
    void Start () {
		render = GetComponent<SpriteRenderer>(); 
		index = PlayerPrefs.GetInt("BgNumber");
		render.sprite = Backgrounds[index];
	}
}
