Shader "Detox/Blended Skybox"
 {
Properties 
	{
		//_Tint ("Tint Color", Color) = (.5, .5, .5, .5)
		_Blend ("Blend", Range(0.0,1.0)) = 0.5

		_SafeSkyBox ("Safe Sky Box", Cube) = "grey" {}
		_CorruptedSkyBox ("Corrupted Sky Box", Cube) = "grey" {}
	}

SubShader 
{
    Tags { "Queue" = "Background" }
    Cull Off
    Fog { Mode Off }
    Lighting Off
    Color [_Tint]
	
	pass
	{
		SetTexture [_SafeSkyBox] { combine texture }
        SetTexture [_CorruptedSkyBox] { constantColor (0,0,0,[_Blend]) combine texture lerp(constant) previous }
	}

}

Fallback "Skybox/6 Sided", 1
}