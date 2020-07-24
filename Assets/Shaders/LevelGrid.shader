Shader "Unlit/LevelGrid"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" { }
		_Color ("Color", Color) = (1, 1, 1, 1)
		_ViewAngle("ViewAngle", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }

        LOD 100

		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float viewDot : COLOR1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _Color;
			float _ViewAngle;

            v2f vert (appdata i)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(i.vertex);
                o.uv = i.uv;

				float3 camViewSpace = normalize(ObjSpaceViewDir(i.vertex));
				o.viewDot = saturate(dot(i.normal, camViewSpace) - _ViewAngle);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                return col * _Color * i.viewDot;
            }
            ENDCG
        }
    }
}
