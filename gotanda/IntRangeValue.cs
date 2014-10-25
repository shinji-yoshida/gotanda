using UnityEngine;
using System.Collections;

namespace gotanda{
	public class IntRangeValue {
		int min;
		int max;
		int value;
		
		public int Min {
			get {
				return min;
			}
		}
		
		public int Max {
			get {
				return max;
			}
		}
		
		public int Value {
			get {
				return value;
			}
		}
		
		public IntRangeValue(int min, int max, int value){
			this.min = min;
			this.max = max;
			this.value = value;
		}
		
		public IntRangeValue(int min, int max) : this(min, max, min){}
		
		public int SelectNormalizedValue(float normalized){
			this.value = Mathf.RoundToInt(min + Length * normalized);
			return value;
		}
		
		public int SelectValue(int value){
			this.value = value;
			return value;
		}

		public void SelectValueClamped (int val){
			if(val > max)
				value = max;
			else if(val < min)
				value = min;
			else
				value = val;
		}
		
		public float NormalizedValue{
			get {
				return (value - min) / ((float)Length);
			}
		}
		
		public int Length{
			get {
				return max - min;
			}
		}
	}
}