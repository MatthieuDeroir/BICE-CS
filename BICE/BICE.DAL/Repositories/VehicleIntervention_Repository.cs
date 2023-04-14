using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BICE.DAL.Repositories;
using BICE.BLL;

namespace BICE.DAL
{
    public class VehicleInterventionRepository : Repository<VehicleIntervention_DAL>
    {
        // Implement the CRUD methods for VehicleIntervention

        public override VehicleIntervention_DAL GetById(int id)
        {
            // Implement the GetById method for VehicleIntervention
        }

        public override IEnumerable<VehicleIntervention_DAL> GetAll()
        {
            // Implement the GetAll method for VehicleIntervention
        }

        public override VehicleIntervention_DAL Insert(VehicleIntervention_DAL vehicleIntervention)
        {
            // Implement the Insert method for VehicleIntervention
        }

        public override VehicleIntervention_DAL Update(VehicleIntervention_DAL vehicleIntervention)
        {
            // Implement the Update method for VehicleIntervention
        }

        public override void Delete(VehicleIntervention_DAL vehicleIntervention)
        {
            // Implement the Delete method for VehicleIntervention
        }
    }
}