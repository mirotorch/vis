using Microsoft.Data.Sqlite;
using Dapper;

namespace Vis.TableModule
{
	internal class Consultation
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

	internal class ConsultationManager
	{

	}

	internal class ConsultationModule
	{

		public DateTime? GetNextConsultationDate(int doctorId)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			var module = new ConsultationModule();

			var consultations = module.ReadConsultation(new { DoctorId = doctorId });

			connection.Close();
			return consultations.Where((c) => c.Beggining == consultations.Max((c) => c.Beggining)).ToList().FirstOrDefault().Beggining;
		}

		public void CreateConsultation(Consultation consultation)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			connection.Insert(consultation);
			connection.Close();
		}

		public List<Consultation> ReadConsultation(object clause)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			List<Consultation> c = connection.GetList<Consultation>(clause).ToList();
			connection.Close();
			return c;
		}

		public void UpdateConsultation(Consultation consultation)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			connection.Update(consultation);
			connection.Close();
		}

		public void DeleteConsultation(Consultation consultation)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			connection.Delete(consultation);
			connection.Close();
		}


	}
}
