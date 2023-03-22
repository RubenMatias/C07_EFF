using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace D02_EF6_CF_v1.Model
{
    public class BlogContext : DbContext
    {
        #region Construtor (connectionstring do App.Config

        public BlogContext() : base("name = BlogEntities") 
        {
        
        
        }
        #endregion

        #region Criação da bd

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //desativar a pluralização das tabelas
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
        #endregion

        #region Tabelas em memória (dbsets)

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Post> Post { get; set; }

        #endregion
    }
}
