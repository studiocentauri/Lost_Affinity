using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GlitchEffect : MonoBehaviour
{
    public Material glitchMaterial; // Assign your glitch material here

    public bool enable;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (glitchMaterial != null)
        {
            // Apply the glitch effect using Graphics.Blit
            Graphics.Blit(source, destination, glitchMaterial);
        }
        else
        {
            // Render normally if no material is assigned
            Graphics.Blit(source, destination);
        }
    }

    public void ToggleGlitchEffect(bool enable)
    {
        if (glitchMaterial != null)
        {
            glitchMaterial.SetFloat("_GlitchAmount", enable ? 1 : 0); // Toggle glitch amount based on enable state
        }
    }

    void Start()
    {
        glitchMaterial.SetFloat("_GlitchAmount",1);
    }
    
}