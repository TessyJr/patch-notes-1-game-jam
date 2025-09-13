// GlitchSprite.shader (Crazy Edition)
// Unity-compatible 2D sprite glitch shader (unlit).
// Adds distortion, flicker, stretch blur, chromatic offset, flipping, and UV tearing.

Shader "Custom/GlitchSprite"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture (tileable)", 2D) = "white" {}
        _Intensity ("Overall Intensity", Range(0,1)) = 0.35
        _FlickerSpeed ("Flicker Speed", Range(0,10)) = 6.0
        _FlickerAmount ("Flicker Amount", Range(0,1)) = 0.7
        _Stretch ("Stretch Strength", Range(0,1)) = 0.4
        _StretchSamples ("Stretch Samples", Range(1,8)) = 4
        _Chroma ("Chromatic Offset", Range(0,0.1)) = 0.03
        _TimeScale ("Time Scale", Range(0,4)) = 1.0
        _Seed ("Seed", Range(0,10)) = 0.0
        _FlipChance ("Flip Chance", Range(0,1)) = 0.25
        _DistortStrength ("Distort Strength", Range(0,0.2)) = 0.05
        _TearStrength ("UV Tear Strength", Range(0,0.5)) = 0.2
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;

            float _Intensity;
            float _FlickerSpeed;
            float _FlickerAmount;
            float _Stretch;
            int _StretchSamples;
            float _Chroma;
            float _TimeScale;
            float _Seed;
            float _FlipChance;
            float _DistortStrength;
            float _TearStrength;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            float hash21(float2 p)
            {
                return frac(sin(dot(p, float2(127.1, 311.7))) * 43758.5453);
            }

            float2 noiseVec(float2 uv, float t)
            {
                float n = tex2D(_NoiseTex, uv * 2.0 + float2(t*0.13, t*0.37) + _Seed).r;
                float n2 = tex2D(_NoiseTex, uv * 3.1 + float2(-t*0.21, t*0.11) + _Seed + 7.0).r;
                return float2(n - 0.5, n2 - 0.5);
            }

            fixed4 sampleChromatic(sampler2D tex, float2 uv, float2 disp, float chroma)
            {
                float2 offR = uv + disp * chroma * float2( 1.0, 0.3);
                float2 offG = uv + disp * chroma * float2( 0.0, 0.0);
                float2 offB = uv + disp * chroma * float2(-1.0,-0.3);
                float r = tex2D(tex, offR).r;
                float g = tex2D(tex, offG).g;
                float b = tex2D(tex, offB).b;
                float a = tex2D(tex, uv).a;
                return fixed4(r,g,b,a);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float t = _Time.y * _TimeScale;

                // Base noise vector
                float2 nvec = noiseVec(i.uv, t);

                // Flicker
                float flickerNoise = hash21(i.uv * 200.0 + floor(t * _FlickerSpeed));
                float flicker = lerp(1.0, flickerNoise, _FlickerAmount * _Intensity);

                // Distortion from noise
                float2 disp = nvec * (_DistortStrength + _Intensity * 0.1);

                // Random tearing (horizontal strips offset)
                float band = hash21(float2(floor(i.uv.y * 40.0), floor(t * 2.0 + _Seed)));
                float2 tear = float2((band - 0.5) * _TearStrength, 0);

                // Random flip chance per-frame
                float flipRand = hash21(float2(floor(t * 10.0), _Seed));
                float2 flipUV = i.uv;
                if(flipRand < _FlipChance * _Intensity)
                {
                    // horizontal or vertical flip randomly
                    if (hash21(float2(t, _Seed*2.0)) > 0.5)
                        flipUV.x = 1.0 - flipUV.x;
                    else
                        flipUV.y = 1.0 - flipUV.y;
                }

                // Stretch / smear
                int samples = max(1, _StretchSamples);
                fixed4 accum = 0;
                float totalWeight = 0;
                float2 dir = normalize(noiseVec(i.uv + 0.002, t) - nvec + 0.0001);
                float maxStep = _Stretch * 0.05;

                for(int s=0;s<8;s++)
                {
                    if(s >= samples) break;
                    float step = ((float)s / max(1, samples-1)) * maxStep;
                    float weight = 1.0 - ((float)s / (float)samples);
                    float2 sampleUV = flipUV + disp + tear + dir * step;
                    fixed4 c = sampleChromatic(_MainTex, sampleUV, disp, _Chroma);
                    accum += c * weight;
                    totalWeight += weight;
                }

                fixed4 col = accum / max(1e-6, totalWeight);
                col.rgb *= flicker;
                col *= i.color;

                // Random inversion effect (rare)
                if (hash21(float2(floor(t*5.0), _Seed*3.0)) < 0.05 * _Intensity)
                {
                    col.rgb = 1.0 - col.rgb;
                }

                return saturate(col);
            }
            ENDCG
        }
    }

    FallBack "Sprites/Default"
}

/*
New Crazy Additions:
- Random flipping (horizontal/vertical)
- UV tearing with horizontal strip displacement
- Stronger distortion from noise
- Occasional color inversion flashes
- Adjustable _FlipChance, _DistortStrength, and _TearStrength

Usage: Same as before, just swap material to this new shader.
*/
