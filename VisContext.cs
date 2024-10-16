using Microsoft.EntityFrameworkCore;
using Vis.Models;

namespace Vis
{
	public class VisContext : DbContext
	{
		private DbSet<Consultation> consultations;
	}
}
