using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GlitchScript : MonoBehaviour
{
    public Material glitchMaterial; // Reference to the glitch material

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (glitchMaterial != null)
        {
            // Apply the glitch effect using the material
            Graphics.Blit(source, destination, glitchMaterial);
            Debug.LogError("Glitch effect applied");
        }
        else
        {
            // Render normally if no material is assigned
            Graphics.Blit(source, destination);
        }
    }

    public void ToggleGlitchEffect(bool enable)
    {
        glitchMaterial.SetFloat("_EffectEnabled", enable ? 1 : 0); // Assuming you have a property in your shader to control this
    }
}