// Made with Amplify Shader Editor v1.9.2.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SkyDome Gradient"
{
	Properties
	{
		[NoScaleOffset][SingleLineTexture]_MainTex("Cubemap", CUBE) = "white" {}
		_CubemapHeight("Cubemap Height", Float) = -1.5
		_CubemapRotation("Cubemap Rotation", Float) = 0
		[Toggle]_ColorTexture("Color / Texture", Float) = 0
		[Toggle]_Grid("Grid", Float) = 1
		_Color("Color", Color) = (1,1,1,1)
		_HighlightCoverage("Highlight Coverage", Float) = -16
		_HighlightPosition("Highlight Position", Vector) = (0,-0.2,0,0)
		[HDR]_GridColor("Grid Color", Color) = (1,1,1,1)
		_GridTiling("GridTiling", Float) = 8
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Background"  "Queue" = "Background+0" }
		Cull Back
		CGPROGRAM
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf StandardCustomLighting keepalpha 
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA
		};

		struct SurfaceOutputCustomLightingCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			Input SurfInput;
			UnityGIInput GIData;
		};

		uniform float _ColorTexture;
		uniform float4 _Color;
		uniform float _HighlightCoverage;
		uniform float3 _HighlightPosition;
		uniform float _Grid;
		uniform float4 _GridColor;
		uniform float _GridTiling;
		uniform samplerCUBE _MainTex;
		uniform float _CubemapRotation;
		uniform float _CubemapHeight;


		float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
		{
			original -= center;
			float C = cos( angle );
			float S = sin( angle );
			float t = 1 - C;
			float m00 = t * u.x * u.x + C;
			float m01 = t * u.x * u.y - S * u.z;
			float m02 = t * u.x * u.z + S * u.y;
			float m10 = t * u.x * u.y + S * u.z;
			float m11 = t * u.y * u.y + C;
			float m12 = t * u.y * u.z - S * u.x;
			float m20 = t * u.x * u.z - S * u.y;
			float m21 = t * u.y * u.z + S * u.x;
			float m22 = t * u.z * u.z + C;
			float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
			return mul( finalMatrix, original ) + center;
		}


		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			#ifdef UNITY_PASS_FORWARDBASE
			float ase_lightAtten = data.atten;
			if( _LightColor0.a == 0)
			ase_lightAtten = 0;
			#else
			float3 ase_lightAttenRGB = gi.light.color / ( ( _LightColor0.rgb ) + 0.000001 );
			float ase_lightAtten = max( max( ase_lightAttenRGB.r, ase_lightAttenRGB.g ), ase_lightAttenRGB.b );
			#endif
			#if defined(HANDLE_SHADOWS_BLENDING_IN_GI)
			half bakedAtten = UnitySampleBakedOcclusion(data.lightmapUV.xy, data.worldPos);
			float zDist = dot(_WorldSpaceCameraPos - data.worldPos, UNITY_MATRIX_V[2].xyz);
			float fadeDist = UnityComputeShadowFadeDistance(data.worldPos, zDist);
			ase_lightAtten = UnityMixRealtimeAndBakedShadows(data.atten, bakedAtten, UnityComputeShadowFade(fadeDist));
			#endif
			float3 ase_worldPos = i.worldPos;
			float temp_output_8_0 = ( 1.0 - length( (ase_worldPos*abs( ( _HighlightCoverage * 0.001 ) ) + _HighlightPosition) ) );
			float2 temp_cast_0 = (_GridTiling).xx;
			float temp_output_2_0_g9 = 0.9;
			float2 appendResult10_g10 = (float2(temp_output_2_0_g9 , temp_output_2_0_g9));
			float2 temp_output_11_0_g10 = ( abs( (frac( ((ase_worldPos).xz*temp_cast_0 + float2( 0,0 )) )*2.0 + -1.0) ) - appendResult10_g10 );
			float2 break16_g10 = ( 1.0 - ( temp_output_11_0_g10 / fwidth( temp_output_11_0_g10 ) ) );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float3 rotatedValue94 = RotateAroundAxis( float3( 0,0,0 ), ase_vertex3Pos, float3(0,1,0), _CubemapRotation );
			float3 break102 = rotatedValue94;
			float3 appendResult103 = (float3(break102.x , ( break102.y + _CubemapHeight ) , break102.z));
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_normWorldNormal = normalize( ase_worldNormal );
			UnityGI gi83 = gi;
			float3 diffNorm83 = ase_normWorldNormal;
			gi83 = UnityGI_Base( data, 1, diffNorm83 );
			float3 indirectDiffuse83 = gi83.indirect.diffuse + diffNorm83 * 0.0001;
			c.rgb = ( (( _ColorTexture )?( texCUBE( _MainTex, appendResult103 ) ):( ( ( _Color * temp_output_8_0 ) + (( _Grid )?( ( _GridColor * saturate( ( (0.0 + (temp_output_8_0 - 0.75) * (1.0 - 0.0) / (1.0 - 0.75)) * ( 1.0 - saturate( min( break16_g10.x , break16_g10.y ) ) ) ) ) ) ):( float4( 0,0,0,0 ) )) ) )) * saturate( ( ase_lightAtten + UNITY_LIGHTMODEL_AMBIENT + float4( indirectDiffuse83 , 0.0 ) ) ) ).rgb;
			c.a = 1;
			return c;
		}

		inline void LightingStandardCustomLighting_GI( inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi )
		{
			s.GIData = data;
		}

		void surf( Input i , inout SurfaceOutputCustomLightingCustom o )
		{
			o.SurfInput = i;
			o.Normal = float3(0,0,1);
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=19202
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;110;-592.7713,-259.3064;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.001;False;1;FLOAT;0
Node;AmplifyShaderEditor.AbsOpNode;111;-474.9511,-260.9307;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;68;-475.4626,-397.195;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode;115;-293.5702,-131.8115;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ScaleAndOffsetNode;58;-287.087,-296.759;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.PosVertexDataNode;92;-819.6856,236.0153;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RotateAboutAxisNode;94;-549.7813,107.7301;Inherit;False;False;4;0;FLOAT3;0,1,0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode;102;-247.7882,157.549;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleAddOpNode;104;-122.3696,167.1933;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.IndirectDiffuseLighting;83;314.6153,1498.958;Inherit;False;Tangent;1;0;FLOAT3;0,0,1;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FogAndAmbientColorsNode;51;280.7286,1431.221;Inherit;False;UNITY_LIGHTMODEL_AMBIENT;0;1;COLOR;0
Node;AmplifyShaderEditor.LightAttenuation;50;331.1246,1362.535;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;84;205.1266,-325.6827;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;103;8.856471,134.3173;Inherit;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;55;520.1117,1376.076;Inherit;False;3;3;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;2;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;67;177.8534,74.16524;Inherit;True;Property;_MainTex;Cubemap;0;2;[NoScaleOffset];[SingleLineTexture];Create;False;0;0;0;False;0;False;-1;None;None;True;0;False;white;LockedToCube;False;Object;-1;Auto;Cube;8;0;SAMPLERCUBE;;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;56;637.4165,1392.144;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;938.2636,-79.17539;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;49;1119.031,-346.4495;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;SkyDome Gradient;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;;0;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;False;0;True;Background;;Background;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;5;False;;10;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;3;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
Node;AmplifyShaderEditor.ToggleSwitchNode;62;863.3425,-246.2085;Inherit;False;Property;_ColorTexture;Color / Texture;4;0;Create;True;0;0;0;False;0;False;0;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;117;741.2323,-383.7082;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;121;85.6051,-44.0927;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;123;388.6051,-70.49271;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;116;-126.4767,-132.8112;Inherit;False;True;False;True;True;1;0;FLOAT3;0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;128;-90.22647,-52.4066;Inherit;False;Grid;-1;;9;a9240ca2be7e49e4f9fa3de380c0dbe9;0;4;8;FLOAT2;0,0;False;5;FLOAT2;8,8;False;6;FLOAT2;0,0;False;2;FLOAT;0.9;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;125;545.6085,-131.3619;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LengthOpNode;2;-94.37247,-297.6292;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;8;39.45049,-296.3357;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;131;-286.726,60.08414;Inherit;False;Property;_GridTiling;GridTiling;10;0;Create;True;0;0;0;False;0;False;8;8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;112;-39.66673,-482.76;Inherit;False;Property;_Color;Color;6;0;Create;True;0;0;0;False;0;False;1,1,1,1;0.6,0.6,0.6,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;4;-782.1879,-259.1234;Inherit;False;Property;_HighlightCoverage;Highlight Coverage;7;0;Create;True;0;0;0;False;0;False;-16;-16;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;11;-478.8007,-193.007;Inherit;False;Property;_HighlightPosition;Highlight Position;8;0;Create;True;0;0;0;False;0;False;0,-0.2,0;0,-0.2,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.Vector3Node;107;-791.7142,-5.595688;Inherit;False;Constant;_Vector0;Vector 0;6;0;Create;True;0;0;0;False;0;False;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;108;-831.7142,134.4043;Inherit;False;Property;_CubemapRotation;Cubemap Rotation;2;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;105;-318.1216,271.2693;Inherit;False;Property;_CubemapHeight;Cubemap Height;1;0;Create;True;0;0;0;False;0;False;-1.5;-1.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;126;329.6085,-242.3619;Inherit;False;Property;_GridColor;Grid Color;9;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,1;2,2,2,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;119;590.872,-227.7031;Inherit;False;Property;_Grid;Grid;5;0;Create;True;0;0;0;False;0;False;1;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;120;245.7671,-85.69749;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;122;85.6051,-210.4927;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0.75;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
WireConnection;110;0;4;0
WireConnection;111;0;110;0
WireConnection;58;0;68;0
WireConnection;58;1;111;0
WireConnection;58;2;11;0
WireConnection;94;0;107;0
WireConnection;94;1;108;0
WireConnection;94;3;92;0
WireConnection;102;0;94;0
WireConnection;104;0;102;1
WireConnection;104;1;105;0
WireConnection;84;0;112;0
WireConnection;84;1;8;0
WireConnection;103;0;102;0
WireConnection;103;1;104;0
WireConnection;103;2;102;2
WireConnection;55;0;50;0
WireConnection;55;1;51;0
WireConnection;55;2;83;0
WireConnection;67;1;103;0
WireConnection;56;0;55;0
WireConnection;10;0;62;0
WireConnection;10;1;56;0
WireConnection;49;13;10;0
WireConnection;62;0;117;0
WireConnection;62;1;67;0
WireConnection;117;0;84;0
WireConnection;117;1;119;0
WireConnection;121;0;128;0
WireConnection;123;0;120;0
WireConnection;116;0;115;0
WireConnection;128;8;116;0
WireConnection;128;5;131;0
WireConnection;125;0;126;0
WireConnection;125;1;123;0
WireConnection;2;0;58;0
WireConnection;8;0;2;0
WireConnection;119;1;125;0
WireConnection;120;0;122;0
WireConnection;120;1;121;0
WireConnection;122;0;8;0
ASEEND*/
//CHKSM=355AA61E7DC42805464AA37D14EF34DF2298B567