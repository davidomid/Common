using System;

namespace Common.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}