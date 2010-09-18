﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlagSync2.Core
{
    public class SyncInfoEventArgs : EventArgs
    {
        private SyncInfo syncInfo;
        public SyncInfo SyncInfo
        {
            get
            {
                return this.syncInfo;
            }
        }

        public SyncInfoEventArgs(SyncInfo syncInfo)
        {
            this.syncInfo = syncInfo;
        }
    }
    public interface ISyncInfoCreator
    {
        /// <summary>
        /// Creates an enumeration of SyncInfos
        /// </summary>
        /// <returns></returns>
        IEnumerable<SyncInfo> CreateSyncInfos();

        /// <summary>
        /// Occurs when a new SyncInfo gets created
        /// </summary>
        event EventHandler<SyncInfoEventArgs> NewSyncInfo;
    }
}
