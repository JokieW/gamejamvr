Shader "Custom/Unlit/Simple texture" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Colour", Color) = (1, 1, 1, 1)
        //[KeywordEnum(Off, On)] _Fog("Fog", Float) = 1

        // alpha blending
        [Enum(UnityEngine.Rendering.BlendMode)] _BlendSrc ("Blend SRC", float) = 5
        [Enum(UnityEngine.Rendering.BlendMode)] _BlendDst("Blend DST", float) = 10

        // depth
        [Toggle] _ZWrite("Depth write", Float) = 1

        // stencil values
        _StencilRef("Stencil Ref", float) = 1
        [Enum(UnityEngine.Rendering.CompareFunction)] _StencilComp("Stencil Compare Function", float) = 8
        [Enum(UnityEngine.Rendering.StencilOp)] _StencilOp("Stencil Op", float) = 0
    }

    SubShader {
        Lighting off

        Blend [_BlendSrc] [_BlendDst]

        Stencil{
            Ref[_StencilRef]
            Pass[_StencilOp]
            Comp[_StencilComp]
        }

        ZWrite [_ZWrite]

        Pass {

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
//#pragma multi_compile _FOG_OFF _FOG_ON
#pragma multi_compile_fog
#include "UnityCG.cginc"


sampler2D _MainTex;
float4 _MainTex_ST;
float4 _Color;


struct v2f {
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
//#if _FOG_ON
    UNITY_FOG_COORDS(2)
//#endif
};


v2f vert(appdata_base v) {
    v2f o;
    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
//#if _FOG_ON
    UNITY_TRANSFER_FOG(o, o.pos);
//#endif
    return o;
}


half4 frag(v2f i) : SV_Target {
    float4 tcol = tex2D(_MainTex, i.uv);
//#if _FOG_ON
    UNITY_APPLY_FOG(i.fogCoord, tcol);
//#endif
    return _Color * tcol;
}

ENDCG

        } // end Pass
    }     // end SubShader

    CustomEditor "RenderQueueMaterialInspector"
}
