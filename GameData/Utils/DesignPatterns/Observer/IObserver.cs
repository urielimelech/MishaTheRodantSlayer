namespace GameData.Utils.DesignPatterns.Observer
{
    public interface IObserver<T>
    {
        void OnNotify(T data);
    }
}