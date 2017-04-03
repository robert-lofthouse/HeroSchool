using System;
using System.Collections.Generic;
public class Item
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string State { get; set; }
    public string Name { get; set; }
    public Type Type { get; set; }
}

public class ItemContainer
{
    private Dictionary<Type, object> items;

    public ItemContainer()
    {
        items = new Dictionary<Type, object>();
    }

    public T Get<T>(int id) where T : Item
    {
        var t = typeof(T);
        if (!items.ContainsKey(t)) return null;
        var dict = items[t] as Dictionary<int, T>;
        if (!dict.ContainsKey(id)) return null;
        return (T)dict[id];
    }

    public void Set<T>(T item) where T : Item
    {
        var t = typeof(T);
        if (!items.ContainsKey(t))
        {
            items[t] = new Dictionary<int, T>();
        }
        var dict = items[t] as Dictionary<int, T>;
        dict[item.Id] = item;
    }

    public Dictionary<int, T> GetAll<T>() where T : Item
    {
        var t = typeof(T);
        if (!items.ContainsKey(t)) return null;
        return items[t] as Dictionary<int, T>;
    }
}