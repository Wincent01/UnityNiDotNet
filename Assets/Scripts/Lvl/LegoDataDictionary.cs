using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Lvl
{
    public class LegoDataDictionary : IDictionary<string, object>
    {
        public const char InfoSeparator = '\u001F';
        private readonly Dictionary<string, (byte, object)> _map;

        public int Count => _map.Count;
        public bool IsReadOnly => false;

        public ICollection<string> Keys => _map.Keys;
        public ICollection<object> Values => _map.Values.Select(v => v.Item2).ToArray();

        public object this[string key]
        {
            get => _map[key].Item2;
            set => Add(key, value);
        }

        public object this[string key, byte type]
        {
            get => _map[key].Item2;
            set => Add(key, value, type);
        }

        public LegoDataDictionary()
        {
            _map = new Dictionary<string, (byte, object)>();
        }

        public void Add(string key, object value, byte type)
            => _map[key] = (type, value);

        public void Add(string key, object value)
        {
            var type =
                value is int ? 1 :
                value is float ? 3 :
                value is double ? 4 :
                value is uint ? 5 :
                value is bool ? 7 :
                value is long ? 8 :
                value is byte[] ? 13 : 0;

            Add(key, value, (byte) type);
        }

        public void Add(KeyValuePair<string, object> item)
            => Add(item.Key, item.Value);

        public void Clear()
            => _map.Clear();

        public bool ContainsKey(string key)
            => _map.ContainsKey(key);

        public bool Contains(KeyValuePair<string, object> item)
            => _map.ContainsKey(item.Key) && _map[item.Key].Item2 == item.Value;

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
            => _map.Remove(key);

        public bool Remove(KeyValuePair<string, object> item)
            => _map.Remove(item.Key);

        public bool TryGetValue(string key, out object value)
        {
            if (_map.TryGetValue(key, out var temp))
            {
                value = temp.Item2;

                return true;
            }

            value = null;

            return false;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            foreach (var k in _map)
            {
                yield return new KeyValuePair<string, object>(k.Key, k.Value.Item2);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override string ToString()
            => ToString("\r\n");

        public string ToString(string separator)
        {
            var str = new StringBuilder();

            foreach (var k in _map)
            {
                string val;

                switch (k.Value.Item2)
                {
                    case Vector2 vec2:
                        val = $"{vec2.x}{InfoSeparator}{vec2.y}";
                        break;

                    case Vector3 vec3:
                        val = $"{vec3.x}{InfoSeparator}{vec3.z}{InfoSeparator}{vec3.y}";
                        break;

                    case Vector4 vec4:
                        val = $"{vec4.x}{InfoSeparator}{vec4.z}{InfoSeparator}{vec4.y}{InfoSeparator}{vec4.w}";
                        break;

                    case LegoDataList list:
                        val = list.ToString();
                        break;

                    default:
                        val = k.Value.Item2.ToString();
                        break;
                }

                str.Append($"{k}={k.Value.Item1}:{val}");

                var i = _map.Keys.ToList().IndexOf(k.Key);

                if (i + 1 < Count)
                    str.Append(separator);
            }

            return str.ToString();
        }

        public static LegoDataDictionary FromDictionary<T>(Dictionary<string, T> dict)
        {
            var ldd = new LegoDataDictionary();

            foreach (var k in dict)
            {
                ldd[k.Key] = k.Value;
            }
            
            return ldd;
        }

        public static LegoDataDictionary FromString(string text, char separator = '\n')
        {
            var dict = new LegoDataDictionary();
            var lines = text.Replace("\r", "").Split(separator);

            foreach (var line in lines)
            {
                var firstEqual = line.IndexOf('=');
                var firstColon = line.IndexOf(':');
                var key = line.Substring(0, firstEqual);
                var type = int.Parse(line.Substring(firstEqual + 1, firstColon - firstEqual - 1));
                var val = line.Substring(firstColon + 1);

                object v;

                switch (type)
                {
                    case 1:
                    case 2:
                        v = int.Parse(val);
                        break;

                    case 3:
                        v = float.Parse(val, CultureInfo.InvariantCulture);
                        break;

                    case 4:
                        v = double.Parse(val);
                        break;

                    case 5:
                    case 6:
                        v = uint.Parse(val);
                        break;

                    case 7:
                        v = int.Parse(val) == 1;
                        break;

                    case 8:
                    case 9:
                        v = long.Parse(val);
                        break;

                    default:
                        if (val.Contains('+'))
                        {
                            v = LegoDataList.FromString(val);
                        }
                        else if (val.Contains('\u001F'))
                        {
                            var floats = val.Split('\u001F').Select(s => float.Parse(s, CultureInfo.InvariantCulture)).ToArray();

                            v =
                                floats.Length == 1 ? floats[0] :
                                floats.Length == 2 ? new Vector2(floats[0], floats[1]) :
                                floats.Length == 3 ? new Vector3(floats[0], floats[1], floats[2]) :
                                floats.Length == 4 ? new Vector4(floats[0], floats[1], floats[2], floats[3]) :
                                (object) val;
                        }
                        else
                        {
                            v = val;
                        }
                        break;
                }

                dict[key, (byte) type] = v;
            }

            return dict;
        }
    }
}