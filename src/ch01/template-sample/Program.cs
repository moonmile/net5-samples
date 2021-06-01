using System;
using System.Collections.Generic;

namespace template_sample
{
    class KeyValues<TKey, TValue> 
    {
        private class KV
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public KV( TKey key, TValue value )
            {
                this.Key = key;
                this.Value = value;
            }
        }

        private List<KV> _lst = new List<KV>();
        public TValue GetValue( TKey key )
        {
            foreach (var it in _lst)
            {
                if (it.Key.Equals(key))
                {
                    return it.Value;
                }
            }
            return default(TValue);
        }
        public void Add( TKey key, TValue value )
        {
            foreach (var it in _lst)
            {
                if (it.Key.Equals(key))
                {
                    it.Value = value;
                    return;
                }
            }
            _lst.Add(new KV(key,value));
        }
        public void Print()
        {
            foreach ( var it in _lst )
            {
                Console.WriteLine($"{it.Key} : {it.Value}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var kv = new KeyValues<int, string>();
            kv.Add(1, "masuda");
            kv.Add(2, "sato");
            kv.Add(3, "yamada");
            kv.Add(2, "SATO");
            kv.Print();
        }
    }
}
