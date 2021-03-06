﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Queries;
using project.Observables;

namespace project.Repositories
{
    /// <summary>
    /// Access practitioner data only
    /// </summary>
    public class PractitionerRepository
    {
        private readonly PractitionerQuery PractitionerQuery = new PractitionerQuery();
        private readonly string ArgumentStart = "?";

        /// <summary>
        /// Get practitioner by id, if monitoring, add them to an instance var of practitioner from "cache"
        /// </summary>
        /// <param name="id"> practitioner id </param>
        /// <returns> A practitioner </returns>
        public async Task<IPractitioner> GetByIdAsync(string id)
        {
            string argument = ArgumentStart + "_id=" + id;
            var practitioners = await PractitionerQuery.GetPractitionersAsync(argument);
            var practitioner = practitioners.ElementAt(0);
            return practitioner;
        }

        /// <summary>
        /// Get a collection of practitioner
        /// </summary>
        /// <returns> a collection of practitioner </returns>
        public async Task<IEnumerable<IPractitioner>> GetAllAsync()
        {
            return await PractitionerQuery.GetPractitionersAsync();
        }

    }
}
