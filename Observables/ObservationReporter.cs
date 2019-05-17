using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Observables
{
    public class ObservationReporter : IObserver<Observation>
    {
        private IDisposable unsubscriber;
        private bool first = true;
        private Observation last;

        public virtual void Subscribe(IObservable<Observation> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Observation value)
        {
            throw new NotImplementedException();
        }
    }
}
