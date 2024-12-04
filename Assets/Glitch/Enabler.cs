using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetKeyDown(KeyCode.G)) // Press G to toggle
    {
        GlitchScript glitch = Camera.main.GetComponent<GlitchScript>();
        if (glitch != null)
        {
            bool currentState = glitch.glitchMaterial.GetFloat("_EffectEnabled") == 1;
            glitch.ToggleGlitchEffect(!currentState);
        }
    }
}
}
