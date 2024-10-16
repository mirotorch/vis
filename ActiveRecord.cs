using Microsoft.Data.Sqlite;
using Dapper;

namespace Vis.ActiveRecord
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

		public void Create()
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			connection.Insert(this);
			connection.Close();
		}

		public void Read(object clause)
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			List<Consultation> c = connection.GetList<Consultation>(clause).ToList();
			connection.Close();
			var res = c.FirstOrDefault();
			if (res != null)
			{
				Id = res.Id;
				Beggining = res.Beggining;
				End = res.End;
				State = res.State;
				LocationId = res.LocationId;
				PatientId = res.PatientId;
				Mark = res.Mark;
			}
		}

		public void Update()
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			connection.Update(this);
			connection.Close();
		}

		public void Delete()
		{
			using SqliteConnection connection = new SqliteConnection("connectionString");
			connection.Open();
			connection.Delete(this);
			connection.Close();
		}
	}

}
