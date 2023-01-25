Shader "Custom/Brighter"
{
    Properties
    {
        _StartColor ("Start Color", Color) = (0, 0, 0, 1)
        _EndColor ("End Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            fixed4 _StartColor;
            fixed4 _EndColor;
            
            float4 vert(float4 vertexPosition:POSITION):POSITION
            {
                return UnityObjectToClipPos(vertexPosition);
            }

            float4 frag(UNITY_VPOS_TYPE screenPos : VPOS):SV_Target
            {
                 return lerp(_StartColor, _EndColor, screenPos.y/_ScreenParams.y);
            }
            ENDCG
        }
    }
}
