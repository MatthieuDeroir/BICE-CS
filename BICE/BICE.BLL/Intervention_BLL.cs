using System;
using System.ComponentModel.DataAnnotations;


namespace BICE.BLL
{
	public class Intervention_BLL
	{
		[Required(ErrorMessage = "Denomination is required !")]
		[StringLength(255, ErrorMessage = "Denomination length cannot exceed 255 characters !")]
		public String Denomination { get; private set; }

		public String? Description { get; private set; }

		[Required(ErrorMessage = "StartDate is required !")]
		public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required !")]
        public DateTime EndDate { get; set; }

        public Intervention_BLL(String _Denomination, String? _Description, DateTime _StartDate, DateTime _EndDate)
		{
			Denomination = _Denomination;
			Description = _Description;
			StartDate = _StartDate;
			EndDate = _EndDate;
		}
	}
}

