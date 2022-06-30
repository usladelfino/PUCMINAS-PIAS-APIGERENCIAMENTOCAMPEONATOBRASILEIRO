﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Messenger
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
