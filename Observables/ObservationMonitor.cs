using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Repositories;

namespace project.Observables
{
    public class ObservationMonitor : IObservable<Observation>
    {
        private List<IObserver<Observation>> observers;
        private List<Observation> observations;
        private ObservationRepository observationRepository;
        private bool monitoringPressure = false;
        private bool monitoringCholesterol = false;
        private bool monitoringTobacco = false;
        public string PatientId { get; set; }


        public ObservationMonitor(string patientId)
        {
            PatientId = patientId;
            observers = new List<IObserver<Observation>>();
            observations = new List<Observation>();
            ObservationCollection.observationMonitors.Add(patientId, this);
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

        public void StartMonitorPressure()
        {
            monitoringPressure = true;
        }

        public void StartMonitorCholesterol()
        {
            monitoringCholesterol = true;
        }

        public void StartMonitorTobacco()
        {
            monitoringTobacco = true;
        }
        
        public async void GetObservationsAsync()
        {
            if (monitoringPressure)
            {
                var retrievedObservations = await observationRepository.GetByPatientAndBloodPressure(PatientId);
                foreach (var o in retrievedObservations)
                {
                    if (observations.Select(observation => observation.Id == o.Id).ToList().Count() == 0)
                    {
                        observations.Add(o);
                    }
                }
            }
            if (monitoringCholesterol)
            {
                var retrievedObservations = await observationRepository.GetByPatientAndTotalCholesterol(PatientId);
                foreach (var o in retrievedObservations)
                {
                    if (observations.Select(observation => observation.Id == o.Id).ToList().Count() == 0)
                    {
                        observations.Add(o);
                    }
                }
            }
            if (monitoringTobacco)
            {
                var retrievedObservations = await observationRepository.GetByPatientAndTobacco(PatientId);
                foreach (var o in retrievedObservations)
                {
                    if (observations.Select(observation => observation.Id == o.Id).ToList().Count() == 0)
                    {
                        observations.Add(o);
                    }
                }
            }
        }
    }
}
