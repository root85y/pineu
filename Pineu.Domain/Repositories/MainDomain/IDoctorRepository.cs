using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pineu.Domain.Repositories.MainDomain;
public interface IDoctorRepository
{
    Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default);
    Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default);
    Task<Doctor?> GetAsync(Guid doctorId, CancellationToken cancellationToken = default);
}
