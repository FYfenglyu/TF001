// references :
// @ https://zhuanlan.zhihu.com/p/133439889
// @ https://blog.csdn.net/chillxiaohan/article/details/107759321
// @ https://blog.csdn.net/WPAPA/article/details/71242812
// @ https://answers.unity.com/questions/980924/ui-mask-with-shader.html

Shader "EdgeLighting"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "yellow" {}
        _lineWidth("lineWidth",Range(0,10)) = 5
        _lineColor("lineColor",Color) = ( 255, 255, 0, 255)

        //MASK SUPPORT ADD
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
        //MASK SUPPORT END
    }

    SubShader
    {
        Tags{
            "Queue" = "Transparent"
        }
        Blend SrcAlpha OneMinusSrcAlpha
        
        //MASK SUPPORT ADD
        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp] 
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }
        ColorMask [_ColorMask]
        //MASK SUPPORT END

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct VertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct VertexOutput
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            VertexOutput vert (VertexInput v)
            {
                VertexOutput o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _lineWidth;
            float4 _lineColor;

            fixed4 frag (VertexOutput i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float2 up_uv = i.uv + float2(0,1) * _lineWidth * _MainTex_TexelSize.xy;
                float2 down_uv = i.uv + float2(0,-1) * _lineWidth * _MainTex_TexelSize.xy;
                float2 left_uv = i.uv + float2(-1,0) * _lineWidth * _MainTex_TexelSize.xy;
                float2 right_uv = i.uv + float2(1,0) * _lineWidth * _MainTex_TexelSize.xy;

                float w = tex2D(_MainTex,up_uv).a * tex2D(_MainTex,down_uv).a * tex2D(_MainTex,left_uv).a * tex2D(_MainTex,right_uv).a;

                col.rgb = lerp(_lineColor,col.rgb,w);
                
                return col;
            }
            ENDCG
        }
    }
}

