using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Observables
{
    public class ObservationMonitor : IObservable<Observation>
    {
        private List<IObserver<Observation>> observers;
        private List<Observation> observations;
        public string patientId { get; set; }

        public ObservationMonitor()
        {
            observers = new List<IObserver<Observation>>();
            observations = new List<Observation>();
        }
        public IDisposable Subscribe(IObserver<Observation> observer)
        {
            if (! observers.Contains(observer))
            {
                observers.Add(observer);
                foreach (var item in observations)
                    observer.OnNext(item);
            }
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Observation>> _observers;
            private IObserver<Observation> _observer;

            public Unsubscriber(List<IObserver<Observation>> observers, IObserver<Observation> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        } 
    }
}
