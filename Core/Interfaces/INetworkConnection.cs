﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }

        void CheckNetworkConnection();
    }
}
