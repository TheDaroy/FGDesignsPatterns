using System;
using System.Collections.Generic;
namespace Tools
{
    public class Event<T> : IObservable<T>, IObserver<T>
    {
        ICollection<IObserver<T>> observers = new List<IObserver<T>>();
        public IDisposable Subscribe(IObserver<T> observer)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(T value)
        {
            throw new NotImplementedException();
        }


    }
}
