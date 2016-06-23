using System;
using UnityEngine;

namespace gotanda
{
	//  based on http://naichilab.blogspot.jp/2013/11/unitycrgbhsv.html 
	public struct HSVColor
	{
		int h;
		int s;
		int v;
		int a;

		public HSVColor (int h, int s, int v, int a)
		{
			this.h = h;
			this.s = s;
			this.v = v;
			this.a = a;
		}

		public static HSVColor FromRGBColor(Color c) {
			return new HSVColor(hOf(c), sOf(c), vOf(c), aOf(c));
		}

		public static int hOf(Color c) {
			float min = Mathf.Min(new float[]{c.r, c.g, c.b});
			float max = Mathf.Max(new float[]{c.r, c.g, c.b});
			
			if (max == 0) return 0;
			
			float h = 0;
			
			if (max == c.r) h = 60 * (c.g - c.b) / (max - min) + 0;
			else if (max == c.g) h = 60 * (c.b - c.r) / (max - min) + 120;
			else if (max == c.b) h = 60 * (c.r - c.g) / (max - min) + 240;
			
			if (h < 0) h += 360;
			
			return (int)Mathf.Round(h);
		}

		public static int sOf(Color c) {
			float min = Mathf.Min(new float[]{c.r, c.g, c.b});
			float max = Mathf.Max(new float[]{c.r, c.g, c.b});
			
			if (max == 0) return 0;
			return (int)(255 * (max - min) / max);
		}

		public static int vOf(Color c) {
			return (int)(255.0f * Mathf.Max(new float[]{c.r, c.g, c.b}));
		}

		public static int aOf(Color c) {
			return (int)(255f * c.a);
		}

		public static implicit operator Color(HSVColor c){
			return InnerToColor((float)c.H, (float)c.S / 255.0f, (float)c.V / 255.0f, c.a / 255.0f);
		}

		static Color InnerToColor(float h, float s, float v, float a) {
			if (s == 0.0) //Gray
			{
				int rgb = Convert.ToInt16((float)(v * 255));
				return new Color(rgb, rgb, rgb);
			}
			else
			{
				int Hi = (int)(Mathf.Floor(h / 60.0f) % 6.0f);
				float f = (h / 60.0f) - Hi;
				
				float p = v * (1 - s);
				float q = v * (1 - f * s);
				float t = v * (1 - (1 - f) * s);
				
				float r = 0.0f;
				float g = 0.0f;
				float b = 0.0f;
				
				switch (Hi)
				{
				case 0: r = v; g = t; b = p; break;
				case 1: r = q; g = v; b = p; break;
				case 2: r = p; g = v; b = t; break;
				case 3: r = p; g = q; b = v; break;    
				case 4: r = t; g = p; b = v; break;
				case 5: r = v; g = p; b = q; break;   
				default: break;
				}
				
				return new Color(r,g,b,a);
			}
		}

		public HSVColor AddH(int n){
			if(n < 0)
				n += 360 * Mathf.CeilToInt(-n / 360f);
			n = (h + n) % 360;
			return new HSVColor(n, s, v, a);
		}

		public HSVColor Plus(HSVColor hsv) {
			return new HSVColor (this.h + hsv.h, this.s + hsv.s, this.v + hsv.v, this.a + hsv.a);
		}

		public HSVColor Minus(HSVColor hsv) {
			return new HSVColor (this.h - hsv.h, this.s - hsv.s, this.v - hsv.v, this.a - hsv.a);
		}

		public HSVColor Mult(float s) {
			return new HSVColor (Mathf.RoundToInt(this.h * s), Mathf.RoundToInt(this.s * s), Mathf.RoundToInt(this.v * s), Mathf.RoundToInt(this.a * s));
		}

		public HSVColor ChangeH (int newH)
		{
			return new HSVColor(newH, s, v, a);
		}

		public int H {
			get {
				return this.h;
			}
		}

		public int S {
			get {
				return this.s;
			}
		}

		public int V {
			get {
				return this.v;
			}
		}
	}
}
