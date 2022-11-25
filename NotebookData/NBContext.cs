using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NotebookData.Mapping.NotebookDB;
using NotebookEntities.NoteBookDB;

namespace NotebookData
{
    public class NBContext : DbContext
    {
        public DbSet<NBNotes> NBNotes { get; set; }

        public NBContext(DbContextOptions<NBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NBNotesMap());
        }
    }
}
