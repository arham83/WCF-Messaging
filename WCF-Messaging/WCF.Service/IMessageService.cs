﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.Service
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        void GetMessages(string msg);
    }
}