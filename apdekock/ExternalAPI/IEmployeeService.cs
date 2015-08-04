﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExternalAPI
{
   
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<string> GetEmployees();
    }


}