using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.SignalR;

namespace WebFramework
{
    public class UpdateDataGrid:Hub , IUpdateDataGrid
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateDataGrid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataSourceResult GetUpdateSourceGrid(DataSourceRequest dataSourceRequest)
        {
            return null; //_unitOfWork.VencoinRepository.GetAllVencoin(dataSourceRequest);
        }
    }
}
