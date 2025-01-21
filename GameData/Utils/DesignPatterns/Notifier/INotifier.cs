
using System;

namespace GameData.Utils.DesignPatterns.Notifier
{
    public interface INotifier<T>
    {
        public abstract void AddObserver(IObserver<T> observer);
        public abstract void RemoveObserver(IObserver<T> observer);
        public abstract void Notify(T data);
    }
}