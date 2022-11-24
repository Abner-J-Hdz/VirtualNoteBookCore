using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotebookEntities.NoteBookDB;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// using 
/// </summary>
namespace NotebookData.Mapping.NotebookDB
{
    public class NBUserMap : IEntityTypeConfiguration<NBUser>
    {
        public void Configure(EntityTypeBuilder<NBUser> builder)
        {
            builder.ToTable("NBUser")
                .HasKey(c => c.IdUser);
        }
    }
}
