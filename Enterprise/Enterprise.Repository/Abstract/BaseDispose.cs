using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Repository.Abstract
{
    public abstract class BaseDispose:IDisposable
    {
        private bool disposed = false;
        
        protected virtual void Dispose(bool disposing,DbContext context)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose(DbContext context)
        {
            Dispose(true,context);
            GC.SuppressFinalize(this);
        }

        public abstract void Dispose();
    }
}
