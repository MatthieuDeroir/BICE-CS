using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BICE.DAL.Repositories;
using BICE.BLL;


namespace BICE.DAL
{
    public class MaterialRepository : Repository<Material_DAL>
    {
        // Implement the CRUD methods for Material

        public override Material_DAL GetById(int id)
        {
            // Implement the GetById method for Material
        }

        public override IEnumerable<Material_DAL> GetAll()
        {
            // Implement the GetAll method for Material
        }

        public override Material_DAL Insert(Material_DAL material)
        {
            // Implement the Insert method for Material
        }

        public override Material_DAL Update(Material_DAL material)
        {
            // Implement the Update method for Material
        }

        public override void Delete(Material_DAL material)
        {
            // Implement the Delete method for Material
        }
    }
}