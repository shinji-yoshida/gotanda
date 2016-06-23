using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;

namespace gotanda {

	/// <summary>
	/// from http://qiita.com/2Lt_FROST/items/68e0410b16b4ea4920d2
	/// </summary>
	[System.Serializable]
	public class UnityDictionary<TKey, TValue, TPair> where TPair : KeyAndValue<TKey, TValue> , new (){
		[SerializeField]
		protected List<TPair> list;                     
		protected Dictionary<TKey, TValue> table;       
		
		public UnityDictionary () {
			list = new List<TPair>();
		}
		
		public Dictionary<TKey, TValue> GetTable () {
			if (table == null) {
				table = ConvertListToDictionary(list);
			}
			return table;
		}
		
		public TValue GetValue (TKey key) {
			if(GetTable ().Keys.Contains(key)){
				return GetTable ()[key];
			}
			//Debug.LogError(key +" は存在しないKeyです");
			return default(TValue);
		}
		
		public void SetValue (TKey key, TValue value) {
			if(GetTable ().Keys.Contains(key)){
				//Debug.Log ("SetValue() Change Value.");
				table[key] = value;
			}else {
				//Debug.Log ("SetValue() Add new table.");
				table.Add(key, value);
			}
		}
		
		public void Reset () {
			table = new Dictionary<TKey, TValue>();
			list = new List<TPair>();
		}
		public void Apply () {
			list = ConvertDictionaryToList(table);
		}
		public void Rebuild() {
			table = ConvertListToDictionary (list);
		}
		
		static Dictionary<TKey, TValue> ConvertListToDictionary (List<TPair> list) {
			Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue> ();
			foreach(KeyAndValue<TKey, TValue> pair in list){
				dic.Add(pair.Key, pair.Value);
			}
			return dic;
		}
		
		static List<TPair> ConvertDictionaryToList (Dictionary<TKey, TValue> table) {
			List<TPair> list = new List<TPair>();
			
			if(table != null){
				foreach(KeyValuePair<TKey, TValue> pair in table){
					TPair type = new TPair();
					type.Key = pair.Key;
					type.Value = pair.Value;
					list.Add(type);
				}
			}
			return list;
		}
	}
	
	/// <summary>
	/// シリアル化できる、KeyValuePairに代わる構造体
	/// </summary>
	[System.Serializable]
	public class KeyAndValue<TKey, TValue>
	{
		public TKey Key;
		public TValue Value;
	}
}
