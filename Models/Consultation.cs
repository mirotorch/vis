namespace Vis.Models
{
	public class Consultation
	{
		public int Id { get; set; }
		public DateTime Beggining { get; set; }
		public DateTime End { get; set; }
		public string State { get; set; }
		public int LocationId { get; set; }
		public int DoctorId { get; set; }
		public int PatientId { get; set; }
		public string Mark { get; set; }
	}
}
