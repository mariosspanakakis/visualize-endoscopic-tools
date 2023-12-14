Shader "Custom/SemiTransparency" {
    Properties
    {
        _Color ("Color", Color) = (0, 0, 0, 0)
        _Strength ("Strength", Range(0.0, 64.0)) = 1.0
        _Cutoff ("Cutoff", Range(1, 32)) = 16
    }
    SubShader{
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf NoLighting alpha:fade

        fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten) {
            fixed4 c;
            c.rgb = s.Albedo;
            c.a = s.Alpha;
            return c;
        }
        #pragma target 3.0

        float _Strength;
        int _Cutoff;
        fixed4 _Color;

        struct Input{
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldNormal;
        };

        void surf(Input IN, inout SurfaceOutput o){
            float prod = dot(IN.viewDir, IN.worldNormal);
            o.Alpha = saturate (1 -  pow(prod, _Cutoff) * _Strength);
        }
        ENDCG
    }
    FallBack "Diffuse"
}