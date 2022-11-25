using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotebookEntities.NoteBookDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotebookData.Mapping.NotebookDB
{
    public class NBNotesMap: IEntityTypeConfiguration<NBNotes>
    {
        public void Configure(EntityTypeBuilder<NBNotes> builder)
        {
            builder.ToTable("NBNotes")
                .HasKey(c => c.IdNote);
        }
    }
}
