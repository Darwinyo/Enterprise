﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Enterprise.Repository.Abstract;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Repository.ProductRepository;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;

namespace Enterprise.Repository.HelperRepository
{
    public class TblPeriodeRepository:HelperBaseRepository<TblPeriode>,ITblPeriodeRepository
    {
        public TblPeriodeRepository(HelperContext context) : base(context)
        {
        }

        public int CreatePeriode(TblPeriode tblPeriode, HelperContext context)
        {
            return context.Database.ExecuteSqlCommand(
                 "EXEC dbo.sp_Generate_Periode @periodeId={0},@periodeDescription={1},@periodeStartDate={2},@periodeEndDate={3}"
                 , tblPeriode.PeriodeId
                 , tblPeriode.PeriodeDescription
                 , tblPeriode.PeriodeStartDate
                 , tblPeriode.PeriodeEndDate);
        }
    }
}