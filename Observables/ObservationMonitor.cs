using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Repositories;

namespace project.Observables
{
    public class ObservationMonitor : IObservable<Observation>, IMonitoring
    {
        public List<IObserver<Observation>> Observers { get; set; }
        public List<Observation> Observations { get; set; }
        private ObservationRepository observationRepository = new ObservationRepository();
        private bool monitoringPressure = true;
        private bool monitoringCholesterol = true;
        private bool monitoringTobacco = true;
        public string PatientId { get; set; }


        public ObservationMonitor(string patientId)
        {
            PatientId = patientId;
            Observers = new List<IObserver<Observation>>();
            Observations = new List<Observation>();
            if (!(ObservationCollection.Observations.ContainsKey(patientId)))
            {
                ObservationCollection.Observations[patientId] = new Dictionary<string, List<Observation>>();
            }
            ObservationCollection.ObservationMonitors[patientId] = this;
            ObservationCollection.ObservationReporters[patientId] = new Dictionary<string, ObservationReporter>();
        }
        public IDisposable Subscribe(IObserver<Observation> observer)
        {
            if (! Observers.Contains(observer))
            {
                Observers.Add(observer);
                foreach (var item in Observations)
                    observer.OnNext(item);
            }
            return new Unsubscriber(Observers, observer);
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

        public void StartMonitor(string type)
        {
            if (type == Observation.BLOOD_PRESSURE)
            {
                StartMonitorPressure();
            }
            else if (type == Observation.CHOLESTEROL)
            {
                StartMonitorCholesterol();
            }
            else if (type == Observation.TOBACCO)
            {
                StartMonitorTobacco();
            }
            GetObservationsAsync();
        }

        private void StartMonitorPressure()
        {
            monitoringPressure = true;
        }

        private void StartMonitorCholesterol()
        {
            monitoringCholesterol = true;
        }

        private void StartMonitorTobacco()
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
                    if (Observations.Where(observation => observation.Id == o.Id).ToList().Count() == 0)
                    {
                        Observations.Add(o);
                    }
                }
            }
            if (monitoringCholesterol)
            {
                var retrievedObservations = await observationRepository.GetByPatientAndTotalCholesterol(PatientId);
                foreach (var o in retrievedObservations)
                {
                    if (Observations.Where(observation => observation.Id == o.Id).ToList().Count() == 0)
                    {
                        Observations.Add(o);
                    }
                }
            }
            if (monitoringTobacco)
            {
                var retrievedObservations = await observationRepository.GetByPatientAndTobacco(PatientId);
                foreach (var o in retrievedObservations)
                {
                    if (Observations.Where(observation => observation.Id == o.Id).ToList().Count() == 0)
                    {
                        Observations.Add(o);
                    }
                }
            }
            foreach (var o in Observations)
            {
                foreach (var observer in Observers)
                {
                    observer.OnNext(o);
                }
            }
        }
    }
}
