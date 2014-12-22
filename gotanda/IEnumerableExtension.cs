using System.Collections;
using System;
using System.Collections.Generic;

namespace gotanda{
	public static class IEnumerableExtension {
		public static void Each<T>(this IEnumerable<T> collection, Action<T> action){
			foreach(var each in collection){
				action(each);
			}
		}

		public static void EachWithIndex<T>(this IEnumerable<T> collection, Action<T, int> action){
			int i = 0;
			foreach(var each in collection){
				action(each, i);
				++i;
			}
		}

		public static IEnumerable<R> Map<T, R>(this IEnumerable<T> collection, Func<T, R> func){
			foreach(var each in collection){
				yield return func(each);
			}
		}
		
		public static IEnumerable<R> Map<T, U, R>(this IEnumerable<Pair<T, U>> collection, Func<T, U, R> func)
			where T : class where U : class
		{
			foreach(var each in collection){
				yield return func(each.first, each.second);
			}
		}
		
		public static IEnumerable<R> MapWithIndex<T, R>(this IEnumerable<T> collection, Func<T, int, R> func){
			int index = 0;
			foreach(var each in collection){
				yield return func(each, index);
				++index;
			}
		}
		
		public static List<R> BatchMap<T, R>(this IEnumerable<T> collection, Func<T, R> func){
			return Map(collection, func).ToList();
		}

		public static IEnumerable<Pair<T, U>> Zip<T, U>(this IEnumerable<T> collection, IEnumerable<U> another)
			where T : class where U : class
		{
			IEnumerator<T> thisEnum = collection.GetEnumerator();
			IEnumerator<U> anotherEnum = another.GetEnumerator();

			while(thisEnum.MoveNext()){
				if(anotherEnum.MoveNext())
					yield return new Pair<T, U>(thisEnum.Current, anotherEnum.Current);
				else
					yield return new Pair<T, U>(thisEnum.Current, null);
			}
		}
		
		public static List<T> ToList<T>(this IEnumerable<T> collection){
			return new List<T>(collection);
		}

		public static IEnumerable<T> Flatten<T, U>(this IEnumerable<U> collection) where U : IEnumerable<T>{
			foreach(var eachCollection in collection){
				foreach(var eachElem in eachCollection)
					yield return eachElem;
			}
		}
		
		public static IEnumerable<T> Flatten<T>(this IEnumerable<T[]> collection){
			foreach(var eachCollection in collection){
				foreach(var eachElem in eachCollection)
					yield return eachElem;
			}
		}

		public static IEnumerable<T> Select<T>(this IEnumerable<T> collection, Predicate<T> func){
			foreach(var each in collection){
				if(func(each))
					yield return each;
			}
		}
		
		public static IEnumerable<T> Reject<T>(this IEnumerable<T> collection, Predicate<T> func){
			foreach(var each in collection){
				if(! func(each))
					yield return each;
			}
		}
		
		public static bool Any<T>(this IEnumerable<T> collection, Predicate<T> func){
			foreach(var each in collection){
				if(func(each))
					return true;
			}
			return false;
		}
		
		public static bool Any(this IEnumerable<bool> collection){
			foreach(var each in collection){
				if(each)
					return true;
			}
			return false;
		}
		
		public static bool All<T>(this IEnumerable<T> collection, Predicate<T> func){
			foreach(var each in collection){
				if(! func(each))
					return false;
			}
			return true;
		}
		
		public static bool All(this IEnumerable<bool> collection){
			foreach(var each in collection){
				if(! each)
					return false;
			}
			return true;
		}
		
		public static bool None<T>(this IEnumerable<T> collection, Predicate<T> func){
			return ! Any(collection, func);
		}
		
		public static bool None(this IEnumerable<bool> collection){
			return ! Any(collection);
		}
		
		public static int Count<T>(this IEnumerable<T> collection, Predicate<T> func){
			int result = 0;
			foreach(var each in collection){
				if(func(each))
					++result;
			}
			return result;
		}
		
		public static int Count<T>(this IEnumerable<T> collection){
			int result = 0;
			var iter = collection.GetEnumerator();
			while(iter.MoveNext())
				++result;
			return result;
		}
		
		public static T Find<T>(this IEnumerable<T> collection, Predicate<T> pred) where T : class{
			foreach(var each in collection){
				if(pred(each))
					return each;
			}
			return null;
		}
		
		public static T? FindStruct<T>(this IEnumerable<T> collection, Predicate<T> pred) where T : struct{
			foreach(var each in collection){
				if(pred(each))
					return each;
			}
			return null;
		}
		
		public static T? Max<T>(this IEnumerable<T> collection) where T : struct, IComparable<T>{
			var iter = collection.GetEnumerator();
			if(! iter.MoveNext())
				return null;

			var max = iter.Current;
			while(iter.MoveNext()){
				if(max.CompareTo(iter.Current) < 0)
					max = iter.Current;
			}

			return max;
		}

		public static string Join<T>(this IEnumerable<T> collection, string seperator){
			var iter = collection.GetEnumerator();
			var result = "";
			if(! iter.MoveNext())
				return result;
			result += iter.Current.ToString();
			while(iter.MoveNext())
				result += seperator + iter.Current.ToString();

			return result;
		}
		
		public static T Reduce<T>(this IEnumerable<T> collection, T init, Func<T, T, T> memoAndItemToReduced){
			foreach(var each in collection){
				init = memoAndItemToReduced(init, each);
			}
			return init;
		}

		public static IEnumerable<T> Type<T>(this IEnumerator enumerator){
			while(enumerator.MoveNext())
				yield return (T) enumerator.Current;
		}
	}
}
