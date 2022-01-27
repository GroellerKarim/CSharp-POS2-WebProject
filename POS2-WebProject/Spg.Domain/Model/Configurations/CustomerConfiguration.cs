using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Declare Address a Value Object
            builder.OwnsOne(c => c.Address);

            // Declare Email address Unique and set index
            builder.HasIndex(c => c.EMail).IsUnique();
        }
    }
}
