using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{
    public record Address(string Street, string ZipCode, string City, string Country);
}
