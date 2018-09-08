using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionSize : MonoBehaviour {

    Animator text;

    Vector3 scale;

	// Use this for initialization
	void Start () {
        this.scale = this.gameObject.transform.localScale;
        text = GetComponent<Animator>();
        text.updateMode = AnimatorUpdateMode.AnimatePhysics;
        text.cullingMode = AnimatorCullingMode.CullCompletely;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.transform.localScale = this.scale;
    }
}