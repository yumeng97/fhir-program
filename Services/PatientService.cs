using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    public class PatientService
    {
        private readonly PatientRepository patientRepository = new PatientRepository();
        private readonly PractitionerRepository practitionerRepository = new PractitionerRepository();

        public async Task<IPatient> GetById(string id)
        {
            return await patientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPatient>> GetAll()
        {
            return await patientRepository.GetAllAsync();
        }

        public async Task<IEnumerable<IPatient>> GetByPractitionerId(string practitionerId, Boolean monitored = false)
        {
            var practitioner = await practitionerRepository.GetByIdAsync(practitionerId);
            if (monitored)
            {
                var patients = new List<IPatient>();
                foreach (string id in practitioner.MonitoredPatients)
                {
                    var patient = await patientRepository.GetByIdAsync(id);
                    patients.Add(patient);
                }
                return patients;
            } else
            {
                var patients = await patientRepository.GetAllAsync();
                foreach (var o in patients.Where(patient => !practitioner.MonitoredPatients.Contains(patient.Id)))
                {
                    Console.WriteLine("not");
                    Console.WriteLine(o.Id);
                }
                return patients.Where(patient => !practitioner.MonitoredPatients.Contains(patient.Id));
            }
            
        }
    }
}
