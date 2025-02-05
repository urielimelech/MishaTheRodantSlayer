
using System;

namespace MishaTheRodantSlayer.Core.Basics.Interfaces
{
    public interface INotifier<T>
    {
        public abstract void AddObserver(IObserver<T> observer);
        public abstract void RemoveObserver(IObserver<T> observer);
        public abstract void Notify(T data);
    }
}