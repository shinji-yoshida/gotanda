using UnityEngine;
using System.Collections;

namespace gotanda{
	public class FloatRangeValue {
		float min;
		float max;
		float value;

		public float Min {
			get {
				return min;
			}
		}

		public float Max {
			get {
				return max;
			}
		}

		public float Value {
			get {
				return value;
			}
		}

		public FloatRangeValue(float min, float max, float value){
			this.min = min;
			this.max = max;
			this.value = value;
		}
		
		public FloatRangeValue(float min, float max) : this(min, max, min){}

		public float SelectNormalizedValue(float normalized){
			this.value = min + Length * normalized;
			return value;
		}

		public float SelectValue(float value){
			this.value = value;
			return value;
		}

		public float NormalizedValue{
			get {
				return (value - min) / Length;
			}
		}

		public float Length{
			get {
				return max - min;
			}
		}
	}
}