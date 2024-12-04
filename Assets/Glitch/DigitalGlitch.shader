Shader "Custom/DigitalGlitch"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GlitchAmount ("Glitch Amount", Range(0, 1)) = 0.5
        _TimeScale ("Time Scale", Range(0, 10)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _GlitchAmount;
            float _TimeScale;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Get the original color from the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Apply glitch effect by offsetting UVs randomly based on time
                float glitchOffset = sin(_Time.y * _TimeScale + i.uv.y * 10.0) * _GlitchAmount;
                i.uv.x += glitchOffset;

                // Sample the texture again with the modified UVs
                fixed4 glitchCol = tex2D(_MainTex, i.uv);

                // Blend original color with glitch color
                return lerp(col, glitchCol, _GlitchAmount);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}