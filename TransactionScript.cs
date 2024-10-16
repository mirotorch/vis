using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis.TransactionScript
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

	internal class TransactionScript
	{
		public DateTime? GetNextConsultationDate(int doctorId)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			var dt = connection.Query<DateTime>(@"SELECT beggining FROM CONSULTATION WHERE doctor_id = @doctorId
			AND beggining >= ALL(SELECT beggining FROM CONSULTATION WHERE doctor_id = @doctorId)", doctorId).FirstOrDefault();
			return dt;
		}
	}
}
