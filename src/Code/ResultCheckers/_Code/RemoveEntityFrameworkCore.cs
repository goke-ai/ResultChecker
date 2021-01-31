#region Assembly Microsoft.EntityFrameworkCore.Abstractions, Version=5.0.2.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// C:\Users\gokel\.nuget\packages\microsoft.entityframeworkcore.abstractions\5.0.2\lib\netstandard2.1\Microsoft.EntityFrameworkCore.Abstractions.dll
#endregion

using Ark.ResultCheckers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.EntityFrameworkCore
{
    //
    // Summary:
    //     Marks a type as owned. All references to this type will be configured as owned
    //     entity types.
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class OwnedAttribute : Attribute
    {
        public OwnedAttribute() { }
    }


    ////////////////////
    ///
    public class DbUpdateConcurrencyException : SystemException//: DbUpdateException
    {
    }

    ///////
    ///
    public class DbContextOptions<T>
    {
    }

    public class DbContextOptionsBuilder
    {
    }

    public abstract class DbSet<TEntity> //: IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable, IAsyncEnumerable<TEntity>, IInfrastructure<IServiceProvider>, IListSource where TEntity : class
    {
        // public virtual IQueryable<TEntity> AsQueryable();
    }

    public class ModelBuilder
    {
    }
    ///
    //
    public class DbContext // : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache, IDbContextPoolable, IResettableService
    {
        private DbContextOptions<AppDbContext> options;

        public DbContext(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }

        protected virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected virtual void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}