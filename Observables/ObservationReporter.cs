using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Observables
{
    public class ObservationReporter : IObserver<Observation>, IMonitoring
    {
        private IDisposable unsubscriber;
        private bool monitoringPressure = true;
        private bool monitoringCholesterol = true;
        private bool monitoringTobacco = true;
        private readonly string PractitionerId;
        private readonly string PatientId;

        public ObservationReporter(string practitionerId, string patientId)
        {
            PractitionerId = practitionerId;
            PatientId = patientId;
            if (!(ObservationCollection.Observations[patientId].ContainsKey(practitionerId)))
            {
                ObservationCollection.Observations[patientId][practitionerId] = new List<Observation>();
            }
            ObservationCollection.ObservationReporters[patientId][practitionerId] = this;
            if (ObservationCollection.MonitoredPatientsByPractitioner.ContainsKey(practitionerId))
            {
                ObservationCollection.MonitoredPatientsByPractitioner[practitionerId].Add(patientId);
            }
            else
            {
                ObservationCollection.MonitoredPatientsByPractitioner[practitionerId] = new List<string>();
                ObservationCollection.MonitoredPatientsByPractitioner[practitionerId].Add(patientId);
            }
        }

        public virtual void Subscribe(IObservable<Observation> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public bool Unsubscribe(string type)
        {
            bool monitoring = true;
            if (type == Observation.BLOOD_PRESSURE)
            {
                monitoringPressure = false;
                ObservationCollection.Observations[PatientId][PractitionerId] = 
                    ObservationCollection.Observations[PatientId][PractitionerId].Where(o => o.Type == Observation.CHOLESTEROL 
                                                                                                || o.Type == Observation.TOBACCO).ToList();
            }
            else if (type == Observation.CHOLESTEROL)
            {
                monitoringCholesterol = false;
                ObservationCollection.Observations[PatientId][PractitionerId] =
                    ObservationCollection.Observations[PatientId][PractitionerId].Where(o => o.Type != Observation.CHOLESTEROL).ToList();
            }
            else if (type == Observation.TOBACCO)
            {
                monitoringTobacco = false;
                ObservationCollection.Observations[PatientId][PractitionerId] =
                    ObservationCollection.Observations[PatientId][PractitionerId].Where(o => o.Type != Observation.TOBACCO).ToList();
            }

            if (! (monitoringTobacco && monitoringPressure && monitoringCholesterol))
            {
                Unsubscribe();
                ObservationCollection.Observations[PatientId].Remove(PractitionerId);
                ObservationCollection.ObservationReporters[PatientId].Remove(PractitionerId);
                if (ObservationCollection.Observations[PatientId].Count() == 0)
                {
                    ObservationCollection.Observations.Remove(PatientId);
                    ObservationCollection.ObservationMonitors.Remove(PatientId);
                }
                monitoring = false;
            }
            return monitoring;
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

        public void OnNext(Observation observation)
        {
            if (((observation.Type == Observation.SYSTOLIC) && (monitoringPressure))
                || ((observation.Type == Observation.CHOLESTEROL) && (monitoringCholesterol))
                    || ((observation.Type == Observation.TOBACCO) && (monitoringTobacco)))
            {
                if (ObservationCollection.Observations[PatientId][PractitionerId].Select(o => o.Id == observation.Id).ToList().Count() == 0)
                {
                    ObservationCollection.Observations[PatientId][PractitionerId].Add(observation);
                }
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
    }
}
