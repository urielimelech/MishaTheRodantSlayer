using System;
using System.Collections.Generic;

namespace GameData.Utils.DesignPatterns.Notifier
{
    public class Notifier<T> : INotifier<T>
    {
        private readonly List<IObserver<T>> observers;

        public Notifier()
        {
            observers = new List<IObserver<T>>();
        }

        public virtual void AddObserver(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public virtual void RemoveObserver(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        public virtual void Notify(T data)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(data);
            }
        }
    }
}