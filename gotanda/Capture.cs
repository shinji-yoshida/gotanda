using UnityEngine;
using System.Collections;
using System;

namespace gotanda{
	/// usage
	/// 
	/// intarface Foo{
	///   void Bar(int n);
	/// }
	/// 
	/// var capture = new Capture<int>();
	/// var mockFoo = new Mock<Foo>();
	/// mockFoo.Setup(f => f.Bar(It.IsAny<int>()).Callback<int>(capture);
	/// mockFoo.Object.Bar(3);
	/// Assert.Equals(3, capture.Arg1);
	/// 
	public class Capture<T1>{
		T1 arg1;
		
		public T1 Arg1 {
			get {
				return arg1;
			}
		}
		
		public Action<T1> Callback(){
			return (arg) => {this.arg1 = arg;};
		}
		
		public static implicit operator Action<T1>(Capture<T1> c){
			return c.Callback();
		}
	}

	public class Capture<T1,T2>{
		T1 arg1;
		T2 arg2;
		
		public T1 Arg1 {
			get {
				return arg1;
			}
		}

		public T2 Arg2 {
			get {
				return arg2;
			}
		}
		
		public Action<T1,T2> Callback(){
			return (arg1, arg2) => {this.arg1 = arg1; this.arg2 = arg2;};
		}
		
		public static implicit operator Action<T1,T2>(Capture<T1,T2> c){
			return c.Callback();
		}
	}
}