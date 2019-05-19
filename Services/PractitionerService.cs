using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;
using project.Observables;

namespace project.Services
{
    /// <summary>
    /// Practitioner Service, calling from repo to perform heavy/heavier logic
    /// </summary>
    public class PractitionerService
    {
        private readonly PractitionerRepository PractitionerRepository = new PractitionerRepository();

        /// <summary>
        /// Get practitioner given id
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <returns> A practitioner</returns>
        public async Task<IPractitioner> GetById(string id)
        {
            return await PractitionerRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get a collection of Practitioner
        /// </summary>
        /// <returns> a collection of Practitioner </returns>
        public async Task<IEnumerable<IPractitioner>> GetAll()
        {
            return await PractitionerRepository.GetAllAsync();
        }

        public void AddPatientMonitor(string id, string patientId, string type)
        {
            if (ObservationCollection.ObservationMonitors.ContainsKey(patientId))
            {
                if (ObservationCollection.ObservationReporters[patientId].ContainsKey(id))
                {
                    var provider = ObservationCollection.ObservationMonitors[patientId];
                    var observer = ObservationCollection.ObservationReporters[patientId][id];
                    provider.StartMonitor(type);
                    observer.StartMonitor(type);
                    provider.Subscribe(observer);
                }
                else
                {
                    var provider = ObservationCollection.ObservationMonitors[patientId];
                    var observer = new ObservationReporter(id, patientId);
                    provider.StartMonitor(type);
                    observer.StartMonitor(type);
                    provider.Subscribe(observer);
                }
            }
            else
            {
                var provider = new ObservationMonitor(patientId);
                var observer = new ObservationReporter(id, patientId);
                provider.StartMonitor(type);
                observer.StartMonitor(type);
                provider.Subscribe(observer);
            }
        }

        public void DeletePatientMonitor(string id, string patientId, string type)
        {
            var observer = ObservationCollection.ObservationReporters[patientId][id];
            observer.Unsubscribe(type);
        }
    }
}
