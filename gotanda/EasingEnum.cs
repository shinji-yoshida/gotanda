using UnityEngine;
using System.Collections;

namespace gotanda{
	[System.Serializable]
	public enum EasingEnum{
		Linear,
		QuadEaseIn, QuadEaseOut, QuadEaseInOut, QuadEaseOutIn,
		BackEaseIn, BackEaseOut, BackEaseInOut, BackEaseOutIn,
		ElasticEaseIn, ElasticEaseOut, ElasticEaseInOut, ElasticEaseOutIn, BounceEaseIn, BounceEaseOut
	}

	public delegate float NormalizedEasing(float progress);

	public static class EasingEnumExtension{
		public static NormalizedEasing NormalizedFunc(this EasingEnum self){
			switch(self){
			case EasingEnum.Linear:
				return LinearNormalized;

			case EasingEnum.QuadEaseIn:
				return QuadEaseInNormalized;
			case EasingEnum.QuadEaseOut:
				return QuadEaseOutNormalized;
			case EasingEnum.QuadEaseInOut:
				return QuadEaseInOutNormalized;
			case EasingEnum.QuadEaseOutIn:
				return QuadEaseOutInNormalized;
				
			case EasingEnum.BackEaseIn:
				return BackEaseInNormalized;
			case EasingEnum.BackEaseOut:
				return BackEaseOutNormalized;
			case EasingEnum.BackEaseInOut:
				return BackEaseInOutNormalized;
			case EasingEnum.BackEaseOutIn:
				return BackEaseOutInNormalized;

			case EasingEnum.ElasticEaseIn:
				return ElasticEaseInNormalized;
			case EasingEnum.ElasticEaseOut:
				return ElasticEaseOutNormalized;
			case EasingEnum.ElasticEaseInOut:
				return ElasticEaseInOutNormalized;
			case EasingEnum.ElasticEaseOutIn:
				return ElasticEaseOutInNormalized;
				
			case EasingEnum.BounceEaseIn:
				return BounceEaseInNormalized;
			case EasingEnum.BounceEaseOut:
				return BounceEaseOutNormalized;
			default:
				throw new UnityException("unknown type " + self);
			}
		}

		public static float LinearNormalized(float progress){
			return (float)Easing.Linear(progress, 0, 1, 1);
		}
		
		public static float QuadEaseInNormalized(float progress){
			return (float)Easing.QuadEaseIn(progress, 0, 1, 1);
		}
		
		public static float QuadEaseOutNormalized(float progress){
			return (float)Easing.QuadEaseOut(progress, 0, 1, 1);
		}
		
		public static float QuadEaseInOutNormalized(float progress){
			return (float)Easing.QuadEaseInOut(progress, 0, 1, 1);
		}
		
		public static float QuadEaseOutInNormalized(float progress){
			return (float)Easing.QuadEaseOutIn(progress, 0, 1, 1);
		}
		
		public static float BackEaseInNormalized(float progress){
			return (float)Easing.BackEaseIn(progress, 0, 1, 1);
		}
		
		public static float BackEaseOutNormalized(float progress){
			return (float)Easing.BackEaseOut(progress, 0, 1, 1);
		}
		
		public static float BackEaseInOutNormalized(float progress){
			return (float)Easing.BackEaseInOut(progress, 0, 1, 1);
		}
		
		public static float BackEaseOutInNormalized(float progress){
			return (float)Easing.BackEaseOutIn(progress, 0, 1, 1);
		}
		
		public static float ElasticEaseInNormalized(float progress){
			return (float)Easing.ElasticEaseIn(progress, 0, 1, 1);
		}
		
		public static float ElasticEaseOutNormalized(float progress){
			return (float)Easing.ElasticEaseOut(progress, 0, 1, 1);
		}
		
		public static float ElasticEaseInOutNormalized(float progress){
			return (float)Easing.ElasticEaseInOut(progress, 0, 1, 1);
		}
		
		public static float ElasticEaseOutInNormalized(float progress){
			return (float)Easing.ElasticEaseOutIn(progress, 0, 1, 1);
		}
		
		public static float BounceEaseInNormalized(float progress){
			return (float)Easing.BounceEaseIn(progress, 0, 1, 1);
		}
		
		public static float BounceEaseOutNormalized(float progress){
			return (float)Easing.BounceEaseOut(progress, 0, 1, 1);
		}
	}
}